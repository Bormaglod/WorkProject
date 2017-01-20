//-----------------------------------------------------------------------
// <copyright file="EntityDetailViewer.cs" company="Sergey Teplyashin">
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
// <date>21.05.2015</date>
// <time>11:25</time>
// <summary>Defines the EntityDetailViewer class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using NHibernate.Criterion;
    using WorkProject.Data;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Repositories;
    using WorkProject.Editors.Base;
    
    public partial class EntityDetailViewer<TContent, TInfo> : EntityViewer<TContent>
        where TContent: Entity
        where TInfo: Entity, ITreeItem
    {
        TableProperty table;
        List<Order> orders = new List<Order>();
        
        public EntityDetailViewer()
        {
            InitializeComponent();
        }
        
        BindingList<TInfo> CurrentDetailList { get { return (BindingList<TInfo>)DetailGridView.DataSource; } }
        
        protected TableProperty DetailTable { get { return table; } }
        
        protected override TableProperty CurrentTable { get { return DetailTable; } }
        
        protected TInfo CurrentDetail
        {
            get
            {
                int row = DetailGridView.CurrentRow == null ? -1 : DetailGridView.CurrentRow.Index;
                return row == -1 ? null : CurrentDetailList[row];
            }
            
            set
            {
                int row = DetailGridView.CurrentRow == null ? -1 : DetailGridView.CurrentRow.Index;
                if (row != -1 && value != null)
                {
                    CurrentDetailList[row] = value;
                }
            }
        }
        
        protected override void InitializeTables(ISession session)
        {
            base.InitializeTables(session);
            table = RepositoryList.Table<TInfo>(session);
            foreach (ColumnItem column in table.Columns.Where(x => x.Sorted > 0).OrderBy(x => x.Sorted))
            {
                orders.Add(Order.Asc(column.Name));
            }
        }
        
        protected override void CreateColumns(ISession session)
        {
            base.CreateColumns(session);
            if (MasterTable.HasChild)
            {
                DataGridHelper.CreateColumns<TInfo>(DetailGridView);
            }
        }
        
        protected override Type GetGroupType()
        {
            return typeof(TInfo);
        }
        
        protected override IList<ITreeItem> GroupList(ISession session)
        {
            return RepositoryList.Get<TInfo>(session).All().List<ITreeItem>();
        }
        
        protected override void MasterEntitySelected(Entity entity)
        {
            base.MasterEntitySelected(entity);
            if (entity == null)
            {
                DetailGridView.DataSource = null;
                return;
            }
            
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    ICriteria criteria = session.CreateCriteria<TInfo>()
                        .Add(Restrictions.Eq(typeof(TContent).Name, CurrentMaster));
                    foreach (Order order in orders)
                    {
                        criteria.AddOrder(order);
                    }
                    
                    BindingList<TInfo> details = new BindingList<TInfo>(criteria.List<TInfo>());
                    DetailGridView.DataSource = details;
                }
            }
        }
        
        protected override void AddDetail()
        {
            base.AddDetail();
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IEditor<TInfo> editor = Editor.Get<TInfo>();
                        TInfo entity = editor.CreateObject(CurrentMaster);
                        if (entity == default(TInfo))
                        {
                            return;
                        }
                        
                        CurrentDetail = RefreshEntity(session, CurrentDetail);
                        CurrentDetailList.Add(entity);
                    }
                    catch (Exception exception)
                    {
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
        }
        
        protected override void EditDetail()
        {
            base.EditDetail();
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IEditor<TInfo> editor = Editor.Get<TInfo>();
                        CurrentDetail = RefreshBeforeEdit(session, CurrentDetail);
                        TInfo current = editor.Edit(CurrentDetail.Id, CurrentMaster);
                        if (current != null)
                        {
                            CurrentDetail = RefreshEntity(session, current);
                        }
                    }
                    catch (Exception exception)
                    {
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
        }
        
        protected override void DeleteDetail()
        {
            base.DeleteDetail();
            if (KryptonMessageBox.Show(Strings.DeleteEntity, Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        RepositoryList.Get<TInfo>(session).Delete(CurrentDetail);
                        transaction.Commit();
                        CurrentDetailList.Remove(CurrentDetail);
                        RefreshMasterEntity(session);
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
        }
        
        protected override void RefreshMasterEntity(ISession session)
        {
            if (DetailTable.RefreshMaster)
            {
                CurrentMaster = session.Get<TContent>(CurrentMaster.Id);
                MasterGridView.Refresh();
            }
        }
        
        protected override T RefreshEntity<T>(ISession session, T entity)
        {
            RefreshMasterEntity(session);
            return base.RefreshEntity(session, entity);
        }
        
        protected override void PrintDetail()
        {
            base.PrintDetail();
            PrintForm<TInfo>(CurrentDetail);
        }
    }
}
