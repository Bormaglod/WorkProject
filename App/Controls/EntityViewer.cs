//-----------------------------------------------------------------------
// <copyright file="EntityViewer.cs" company="Sergey Teplyashin">
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
// <date>20.05.2015</date>
// <time>12:57</time>
// <summary>Defines the EntityViewer class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using NHibernate.Criterion;
    using WorkProject.Data;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Infrastructure;
    using WorkProject.Printing;
    using WorkProject.Data.Repositories;
    using WorkProject.Editors.Base;

    public partial class EntityViewer<TContent> : UserControl, IViewer where TContent: Entity
    {
        TableProperty table;
        BindingList<TContent> entities;
        Type groupType;
        int curRow = -1;
        
        public EntityViewer()
        {
            DefineGroupType();
            InitializeComponent();
            gridMaster.AutoGenerateColumns = false;
            gridDetail.AutoGenerateColumns = false;
            
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    DoInitializeTables(session);
                    
                    splitTree.Panel1Collapsed = !table.HasGroup;
                    splitDetail.Panel2Collapsed = !table.HasChild;
                    
                    DefineColumns(session);
                    
                    ICriteria criteria = session.CreateCriteria<TContent>();
                    foreach (ColumnItem column in table.Columns.Where(x => x.Sorted > 0).OrderBy(x => x.Sorted))
                    {
                        criteria.AddOrder(Order.Asc(column.Name));
                    }
                    
                    entities = new BindingList<TContent>(criteria.List<TContent>());
                    
                    if (table.HasGroup)
                    {
                        groupTree.AddItems(GetGroupList(session), table.Title);
                    }
                    else
                    {
                        gridMaster.DataSource = entities;
                    }
                    
                    DefineAdditionalTools(session);
                }
            }
            
            UpdateGroupButtons();
            UpdateGridButtons();
            separatorSend.Visible = typeof(TContent).GetInterface("IDocumentStatus") != null;
            toolSend.Visible = separatorSend.Visible;
        }
        
        #region IViewer implemented
        
        ITreeItem IViewer.CurrentGroup
        {
            get { return groupTree.SelectedItem as ITreeItem; }
        }
        
        #endregion
        
        protected Type GroupType
        {
            get { return groupType; }
        }
        
        protected BindingList<TContent> CurrentMasterList
        {
            get
            {
                return (BindingList<TContent>)gridMaster.DataSource;
            }
        }
        
        protected TContent CurrentMaster
        {
            get
            {
                return curRow == -1 ? null : CurrentMasterList[curRow];
            }
            
            set
            {
                if (curRow != -1 && value != null)
                {
                    CurrentMasterList[curRow] = value;
                }
            }
        }
        
        protected KryptonDataGridView MasterGridView { get { return gridMaster; } }
        
        protected KryptonDataGridView DetailGridView { get { return gridDetail; } }
        
        protected TableProperty MasterTable { get { return table; } }
        
        protected virtual TableProperty CurrentTable { get { return MasterTable; } }
        
        protected virtual void CreateColumns(ISession session)
        {
            DataGridHelper.CreateColumns(gridMaster, MasterTable);
        }
        
        protected virtual void MasterEntitySelected(Entity entity) { }
        
        protected virtual void UpdateGridButtons(bool enableEdit) {}
        
        protected virtual void AddDetail() {}
        
        protected virtual void CopyDetail() {}
        
        protected virtual void EditDetail() {}
        
        protected virtual void DeleteDetail() {}
        
        protected virtual void PrintDetail() {}
        
        protected virtual Type GetGroupType()
        {
            return typeof(GroupItem);
        }
        
        protected virtual IList<ITreeItem> GroupList(ISession session)
        {
            return MasterTable.Groups.Cast<ITreeItem>().ToList();
        }
        
        protected ToolStrip DetailTools { get { return toolStripDetail; } }
        
        protected virtual void CreateAdditionalTools(ISession session) {}
        
        protected virtual void InitializeTables(ISession session)
        {
            table = RepositoryList.Table<TContent>(session);
        }
        
        protected T RefreshCurrent<T>(ISession session, T entity) where T: Entity
        {
            if (entity == null)
            {
                return default(T);
            }
            
            if (CurrentTable.RefreshCurrent)
            {
                return session.Get<T>(entity.Id);
            }
            
            return entity;
        }
        
        protected T RefreshBeforeEdit<T>(ISession session, T entity) where T: Entity
        {
            if (CurrentTable.RefreshBefore)
            {
                return session.Get<T>(entity.Id);
            }
            
            return entity;
        }
        
        protected virtual void RefreshMasterEntity(ISession session)
        {
            throw new Exception("Нельзя вызывать обновление для MasterTable находясь в MasterTable");
        }
        
        protected virtual T RefreshEntity<T>(ISession session, T entity) where T: Entity
        {
            return RefreshCurrent(session, entity);
        }
        
        protected void PrintForm<T>(T entity) where T:Entity
        {
            IPrinting<T> printer = Printer.Get<T>();
            if (printer == null)
            {
                KryptonMessageBox.Show(Strings.PrintNotAvailable, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                printer.Print(entity);
            }
        }
        
        void DefineGroupType()
        {
            groupType = GetGroupType();
        }
        
        void DefineColumns(ISession session)
        {
            CreateColumns(session);
        }
        
        void DefineAdditionalTools(ISession session)
        {
            CreateAdditionalTools(session);
        }
        
        void DoInitializeTables(ISession session)
        {
            InitializeTables(session);
        }
        
        IList<ITreeItem> GetGroupList(ISession session)
        {
            return GroupList(session);
        }
        
        void UpdateGroupButtons()
        {
            bool enableEdit = groupType == typeof(GroupItem);
            toolAddGroup.Enabled = enableEdit;
            toolEditGroup.Enabled = enableEdit && groupTree.SelectedItem != null;
            toolDeleteGroup.Enabled = enableEdit && groupTree.SelectedItem != null;
            
            menuAddGroup.Enabled = toolAddGroup.Enabled;
            menuEditGroup.Enabled = toolEditGroup.Enabled;
            menuDeleteGroup.Enabled = toolDeleteGroup.Enabled;
        }
        
        void UpdateGridButtons()
        {
            bool enableEdit = /*!repository.ReadOnly && */gridMaster.CurrentRow != null;
            //toolAddRec.Enabled = !repository.ReadOnly;
            toolEditMaster.Enabled = enableEdit;
            toolCopyMaster.Enabled = enableEdit;
            toolDeleteMaster.Enabled = enableEdit;
            toolPrintMaster.Enabled = enableEdit;
            
            
            //menuAddRec.Enabled = !repository.ReadOnly;
            menuEditMaster.Enabled = enableEdit;
            menuCopyMaster.Enabled = enableEdit;
            menuDeleteMaster.Enabled = enableEdit;
            menuPrintMaster.Enabled = enableEdit;
            
            toolSend.Enabled = enableEdit && toolSend.Visible && ((IDocumentStatus)CurrentMaster).CanSend;
            
            //enableEdit = gridDetail.CurrentRow != null;
            toolEditDetail.Enabled = enableEdit;
            toolCopyDetail.Enabled = enableEdit;
            toolDeleteDetail.Enabled = enableEdit;
            toolPrintDetail.Enabled = enableEdit;
            
            menuEditDetail.Enabled = enableEdit;
            menuCopyDetail.Enabled = enableEdit;
            menuDeleteDetail.Enabled = enableEdit;
            menuPrintDetail.Enabled = enableEdit;
            
            //toolAddFilter.Enabled = userFilters.FirstOrDefault() != null;
            
            UpdateGridButtons(enableEdit);
        }
        
        void AddEntity(TContent entity)
        {
            if (CurrentMasterList != entities)
            {
                entities.Add(entity);
            }
        }
        
        void RefreshEntities()
        {
            int treeId = groupTree.SelectedId;
            
            PropertyInfo pi = typeof(TContent).GetProperties().FirstOrDefault(p => p.PropertyType == GroupType);
            if (pi != null)
            {
                if (groupTree.SelectedItem == null && MasterTable.ShowAllRoot)
                {
                    gridMaster.DataSource = entities;
                    return;
                }
                else
                {
                    
                    IEnumerable<TContent> currentList = entities
                        .Where(x =>
                               {
                                   Entity refCur = pi.GetValue(x, null) as Entity;
                                   int refId = refCur == null ? 0 : refCur.Id;
                                   return refId == treeId;
                               }
                              );

                    gridMaster.DataSource = new BindingList<TContent>(currentList.ToList());
                    return;
                }
            }
            
            gridMaster.DataSource = entities;
        }
        
        void ToolAddGroupClick(object sender, EventArgs e)
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IEditor<GroupItem> editor = Editor.Get<GroupItem>();
                        GroupItem @group = editor.CreateObject(this, MasterTable);
                        if (@group != null)
                        {
                            groupTree.AddItem(@group);
                        }
                    }
                    catch (Exception exception)
                    {
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
        }
        
        void ToolEditGroupClick(object sender, EventArgs e)
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IEditor<GroupItem> editor = Editor.Get<GroupItem>();
                        GroupItem current = editor.Edit(((GroupItem)groupTree.SelectedItem).Id);
                        if (current  != null)
                        {
                            groupTree.SelectedItem = current;
                            if (groupTree.ParentId == current.Parent_Id.GetValueOrDefault())
                            {
                                groupTree.RefreshSelectedItem();
                            }
                            else
                            {
                                groupTree.MoveItem(current);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
        }
        
        void ToolDeleteGroupClick(object sender, EventArgs e)
        {
            if (KryptonMessageBox.Show(Strings.DeleteGroup, Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        GroupItem current = (GroupItem)groupTree.SelectedItem;
                        RepositoryList.Get<GroupItem>(session).Delete(current);
                        transaction.Commit();
                        groupTree.RemoveItem(current);
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
        }
        
        void GroupTreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshEntities();
            if (MasterTable.ShowAllRoot)
            {
                foreach (DataGridViewColumn c in gridMaster.Columns)
                {
                    ColumnItem ci = (ColumnItem)c.Tag;
                    if (ci.Visible)
                    {
                        c.Visible = groupTree.SelectedItem == null || (!ci.HideOnGroup);
                    }
                }
            }
            
            UpdateGroupButtons();
        }
        
        void GridMasterSelectionChanged(object sender, EventArgs e)
        {
            if (gridMaster.CurrentRow == null || !gridMaster.CurrentRow.Selected)
            {
                MasterEntitySelected(null);
                return;
            }
            
            curRow = gridMaster.CurrentRow.Index;
            if (MasterTable.HasChild)
            {
                MasterEntitySelected(CurrentMaster);
            }
            
            UpdateGridButtons();
        }
        
        void ToolAddDetailClick(object sender, EventArgs e)
        {
            AddDetail();
            UpdateGridButtons();
        }
        
        void ToolCopyDetailClick(object sender, EventArgs e)
        {
            CopyDetail();
            UpdateGridButtons();
        }
        
        void ToolEditDetailClick(object sender, EventArgs e)
        {
            EditDetail();
            UpdateGridButtons();
        }
        
        void ToolDeleteDetailClick(object sender, EventArgs e)
        {
            DeleteDetail();
            UpdateGridButtons();
        }
        
        void ToolAddMasterClick(object sender, EventArgs e)
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IEditor<TContent> editor = Editor.Get<TContent>();
                        TContent entity = editor.CreateObject(this);
                        if (entity == default(TContent))
                        {
                            return;
                        }
                        
                        entity = RefreshCurrent(session, entity);
                        AddEntity(entity);
                        if (entity.GetReferenceId(GroupType) == groupTree.SelectedId || (groupTree.SelectedId == 0 && MasterTable.ShowAllRoot))
                        {
                            CurrentMasterList.Add(entity);
                        }
                    }
                    catch (Exception exception)
                    {
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }       
            
            UpdateGridButtons();
        }
        
        void ToolCopyMasterClick(object sender, EventArgs e)
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IEditor<TContent> editor = Editor.Get<TContent>();
                        TContent entity = editor.CreateObject(CurrentMaster);
                        if (entity == default(TContent))
                        {
                            return;
                        }
                        
                        entity = RefreshCurrent(session, entity);
                        AddEntity(entity);
                        if (entity.GetReferenceId(GroupType) == groupTree.SelectedId || (groupTree.SelectedId == 0 && MasterTable.ShowAllRoot))
                        {
                            CurrentMasterList.Add(entity);
                        }
                    }
                    catch (Exception exception)
                    {
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }       
            
            UpdateGridButtons();
        }
        
        void ToolEditMasterClick(object sender, EventArgs e)
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        IEditor<TContent> editor = Editor.Get<TContent>();
                        if (editor == null)
                        {
                            KryptonMessageBox.Show(Strings.EditorFormRequired, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                        CurrentMaster = RefreshBeforeEdit(session, CurrentMaster);
                        
                        TContent obj = editor.Edit(CurrentMaster.Id);
                        if (obj != null)
                        {
                            obj = RefreshCurrent(session, obj);
                            
                            CurrentMaster = obj;
                            if (CurrentMasterList != entities)
                            {
                                TContent globalObj = entities.FirstOrDefault(x => x.Id == obj.Id);
                                if (globalObj != null)
                                {
                                    entities[entities.IndexOf(globalObj)] = obj;
                                }
                            }
                            
                            if (MasterTable.HasGroup)
                            {
                                int groupId = CurrentMaster.GetReferenceId(GroupType);
                                if (groupId != groupTree.SelectedId && (groupTree.SelectedId != 0 || !MasterTable.ShowAllRoot))
                                {
                                    CurrentMasterList.Remove(CurrentMaster);
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
            
            UpdateGridButtons();
        }
        
        void ToolDeleteMasterClick(object sender, EventArgs e)
        {
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
                        RepositoryList.Get<TContent>(session).Delete(CurrentMaster);
                        transaction.Commit();
                        if (CurrentMasterList != entities)
                        {
                            entities.Remove(CurrentMaster);
                        }
                        
                        CurrentMasterList.Remove(CurrentMaster);
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
            
            UpdateGridButtons();
        }
        
        void ToolPrintMasterClick(object sender, EventArgs e)
        {
            PrintForm<TContent>(CurrentMaster);
        }
        
        void ToolPrintDetailClick(object sender, EventArgs e)
        {
            PrintDetail();
            UpdateGridButtons();
        }
        
        void ToolSendClick(object sender, EventArgs e)
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    IDocumentStatus doc = CurrentMaster as IDocumentStatus;
                    if (doc != null)
                    {
                        doc.Send(DateTime.Now);
                        session.Update(doc);
                        transaction.Commit();
                        gridMaster.Refresh();
                    }
                }
            }
        }
    }
}
