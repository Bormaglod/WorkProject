//-----------------------------------------------------------------------
// <copyright file="ItemsSelector.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergio.teplyashin@gmail.com</email>
// <license>
//     This program is free software; you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation; either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </license>
// <date>05.05.2015</date>
// <time>14:15</time>
// <summary>Defines the ItemsSelector class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using WorkProject.Controls;
    using WorkProject.Data;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Repositories;

    public partial class SelectItemsDialog<TItem, TValue> : KryptonForm
        where TItem: Item
        where TValue: Entity, IResource
    {
        IList<TValue> checkedList;
        IList<TValue> items;
        bool lockList;
        
        public SelectItemsDialog()
        {
            InitializeComponent();
            treeGroups.CountDataContains = true;
        }
        
        public IEnumerable<TValue> GetItems(IEnumerable<TItem> items)
        {
            PropertyInfo p = typeof(TItem).GetProperties().FirstOrDefault(x => x.PropertyType == typeof(TValue));
            checkedList = items
                .Select<TItem, TValue>(x => (TValue)p.GetValue(x, null))
                .ToList<TValue>();
            
            FillData();
            return ShowDialog() == DialogResult.OK ? checkedList : null;
        }
        
        TableProperty TableValues(ISession session)
        {
            if (typeof(TValue) == typeof(MaterialDetail))
            {
                return RepositoryList.Table<Material>(session);
            }
            
            return RepositoryList.Table<TValue>(session);
        }
        
        void FillData()
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    items = RepositoryList.Get<TValue>(session).All().List<TValue>();
                    TableProperty table = TableValues(session);
                    if (table.HasGroup)
                    {
                        kryptonSplitContainer1.Panel1Collapsed = false;
                        treeGroups.AddItems(table.Groups, table.Title);
                    }
                    else if (typeof(TValue).GetInterface("ITreeItem") != null)
                    {
                        kryptonSplitContainer1.Panel1Collapsed = false;
                        treeGroups.AddItems(session.CreateCriteria<Product>().List<Product>(), Strings.Products);
                    }
                    else
                    {
                        kryptonSplitContainer1.Panel1Collapsed = true;
                        listItems.Items.AddRange(items.ToArray());
                        UpdateChecked();
                    }
                }
            }
        }
        
        void Lock()
        {
            lockList = true;
        }
        
        void Unlock()
        {
            lockList = false;
        }
        
        void UpdateChecked()
        {
            Lock();
            try
            {
                for (int i = 0; i < listItems.Items.Count; i++)
                {
                    Entity e = checkedList.FirstOrDefault(x => x.Id == ((TValue)listItems.Items[i]).Id);
                    if (e != null)
                    {
                        listItems.SetItemChecked(i, true);
                    }
                }
            }
            finally
            {
                Unlock();
            }
        }
        
        void TreeGroupsAfterSelect(object sender, TreeViewEventArgs e)
        {
            listItems.Items.Clear();
            int treeItemId = treeGroups.SelectedId;

            IEnumerable<Entity> currentList = items
                .Where(x =>
                       {
                           int refId = x.Group == null ? 0 : x.Group.Id;
                           return refId == treeItemId;
                       }
                      );
            
            listItems.Items.AddRange(currentList.ToArray());
            
            UpdateChecked();
        }
        
        void ListItemsItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (lockList || e.CurrentValue == e.NewValue)
            {
                return;
            }
            
            if (e.NewValue == CheckState.Checked)
            {
                checkedList.Add((TValue)listItems.Items[e.Index]);
                if (!kryptonSplitContainer1.Panel1Collapsed)
                {
                    treeGroups.IncrementContentSelected();
                }
            }
            else
            {
                TValue entity = checkedList.FirstOrDefault(x => x.Id == ((TValue)listItems.Items[e.Index]).Id);
                checkedList.Remove(entity);
                if (!kryptonSplitContainer1.Panel1Collapsed)
                {
                    treeGroups.DecrementContentSelected();
                }
            }
        }
        
        void TreeGroupsCountItems(object sender, CountItemsEventArgs e)
        {
            e.CountItems = checkedList.Count(x => ((x.Group == e.ItemTree) || (x.Group != null && e.ItemTree != null && x.Group.Id == e.ItemTree.Id)));
        }
    }
}
