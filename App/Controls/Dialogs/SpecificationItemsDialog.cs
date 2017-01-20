//-----------------------------------------------------------------------
// <copyright file="SpecificationItemsSelector.cs" company="Sergey Teplyashin">
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
// <date>07.05.2015</date>
// <time>10:49</time>
// <summary>Defines the SpecificationItemsSelector class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Criterion;
    using WorkProject.Controls;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Repositories;

    public partial class SpecificationItemsDialog<TItem, TValue> : KryptonForm, IItemsDialog 
        where TItem: ItemSpecification, new()
        where TValue: Entity, IResource
    {
        BindingList<TItem> items;
        Dictionary<int, decimal> sum;
        ISession session;
        Article article;
        Specification specification;
        
        public SpecificationItemsDialog()
        {
            InitializeComponent();
            sum = new Dictionary<int, decimal>();
        }
        
        #region IItemsDialog implemented
        
        public bool ShowDialog(ISession session, Specification specification, Article article)
        {
            this.session = session;
            this.article = article;
            this.specification = specification;
            
            gridItems.AutoGenerateColumns = false;
            DataGridHelper.CreateColumns(gridItems, RepositoryList.Table<TItem>(session));
            
            items = new BindingList<TItem>(
                session.CreateCriteria<TItem>()
                    .Add(Restrictions.Eq("Article", article))
                    .Add(Restrictions.Eq("Specification", specification))
                    .List<TItem>());
            
            items.ListChanged += BindingSourceCurrentItemChanged;
            headerGroup.ValuesSecondary.Description = items.Sum(x => x.Summa).ToString("0.00");
            gridItems.DataSource = items;
            
            if (typeof(TItem) == typeof(ItemTax))
            {
                var list = from q in session.Query<ItemSpecification>()
                    where q.Specification.Id == specification.Id
                    group q by q.Article.Id 
                    into g
                    select new {
                        Article = g.Key,
                        Summa = g.Sum(_ => _.Summa)
                    };
                
                foreach (var g in list)
                {
                    sum.Add(g.Article, g.Summa);
                }
            }
            
            if (ShowDialog() == DialogResult.OK)
            {
                foreach (TItem i in items)
                {
                    session.SaveOrUpdate(i);
                }
                
                return true;
            }
            
            return false;
        }
        
        #endregion
        
        TItem Current
        {
            get
            {
                int row = gridItems.CurrentRow.Index;
                return row == -1 ? null : items[row];
            }
        }
        
        decimal GetSumma(Entity a)
        {
            return a == null ? 0 : (sum.ContainsKey(a.Id) ? sum[a.Id] : 0);
        }
        
        void RefreshItemSpecification(TItem item)
        {
            if (typeof(TItem) == typeof(ItemTax))
            {
                item.Summa = Math.Round(item.CountItems * GetSumma((item as ItemTax).Source) / 100, 2);
            }
            else
            {
                item.Summa = Math.Round(item.Price * item.CountItems, 2);
            }
        }
        
        void AddNewEntities(IEnumerable<TValue> entities)
        {
            PropertyInfo p;
            if (typeof(TItem) == typeof(ItemProduct))
            {
                p = typeof(TItem).GetProperty("Product");
            }
            else
            {
                p = typeof(TItem).GetProperty(typeof(TValue).Name);
            }
            
            foreach (IResource e in entities.OfType<IResource>())
            {
                TItem item = items.FirstOrDefault(x => {
                                                      Entity entity = (TValue)p.GetValue(x, null);
                                                      return entity.Id == ((TValue)e).Id;
                                                  });
                if (item == null)
                {
                    TItem t = new TItem();
                    t.Article = article;
                    t.Price = e.Price;
                    t.Specification = specification;
                    t.CountItems = e.DefaultCountItems;
                    p.SetValue(t, e, null);
                    RefreshItemSpecification(t);
                    items.Add(t);
                }
            }
        }
        
        void DeleteItems(IEnumerable<TValue> entities)
        {
            PropertyInfo p = typeof(TItem).GetProperty(typeof(TValue).Name);
            
            foreach (TItem i in items)
            {
                TValue g = (TValue)p.GetValue(i, null);
                if (entities.FirstOrDefault(x => x.Id == g.Id) == null)
                {
                    session.Delete(i);
                    items.Remove(i);
                }
            }
        }
        
        void ButtonAddClick(object sender, EventArgs e)
        {
            SelectItemsDialog<TItem, TValue> f = new SelectItemsDialog<TItem, TValue>();
            IEnumerable<TValue> entities = f.GetItems(items);
            if (entities != null)
            {
                DeleteItems(entities);
                AddNewEntities(entities);
            }
        }
        
        void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Current != null)
            {
                session.Delete(Current);
                items.Remove(Current);
            }
        }
        
        void GridItemsCellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.DesiredType != typeof(Article))
            {
                return;
            }
            
            ItemTax itemTax = Current as ItemTax;
            if (itemTax == null)
            {
                return;
            }
            
            itemTax.Source = session.QueryOver<Article>().Where(x => x.Name == e.Value.ToString()).SingleOrDefault();
            itemTax.Summa = Math.Round(itemTax.CountItems * GetSumma(itemTax.Source) / 100, 2);
            
            e.Value = itemTax.Source;
            e.ParsingApplied = true;
        }
        
        void BindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            headerGroup.ValuesSecondary.Description = items.Sum(x => x.Summa).ToString("0.00");
        }
        
        void GridItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != gridItems.ColumnCount - 1)
            {
                RefreshItemSpecification(Current);
            }
        }
    }
}
