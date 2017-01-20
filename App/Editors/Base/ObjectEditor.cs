//-----------------------------------------------------------------------
// <copyright file="ObjectEditor.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2015 Sergey Teplyashin. All rights reserved.
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
// <date>23.10.2014</date>
// <time>15:18</time>
// <summary>Defines the ObjectEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors.Base
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using WorkProject.Controls;
    using WorkProject.Data;
    using WorkProject.Data.Base;
    using WorkProject.Data.Repositories;
    using WorkProject.Printing;

    public /*abstract */partial class ObjectEditor<T> : KryptonForm, IEditor<T> where T: Entity, new()
    {
        ISession session;
        T current;
        Entity master;
        int locked;
        IViewer viewer;
        
        protected ObjectEditor()
        {
            InitializeComponent();
            SetEnabledPrinting();
        }
        
        protected T Current { get { return current; } }
        
        protected ISession Session { get { return session; } }
        
        protected Entity MasterEntity { get { return master; } }
        
        protected bool Locked { get { return locked > 0; } }
        
        protected IViewer Viewer { get { return viewer; } }
        
        T NewObject(IViewer tableViewer, T fromEntity = default(T))
        {
            OnInitialize();
            try
            {
                Text = RepositoryList.Table<T>(session).Title + " (новый)";
                
                viewer = tableViewer;
                current = new T();
                if (fromEntity != default(T))
                {
                    fromEntity.CopyTo(current);
                    session.Save(current);
                    DoBeforeEditingObject();
                }
                else
                {
                    DoBeforeCreatingObject();
                }
                
                if (ShowDialog() == DialogResult.OK)
                {
                    session.Transaction.Commit();
                    return current;
                }
                
                session.Transaction.Rollback();
                return null;
            }
            finally
            {
                OnFinalize();
            }
        }
        
        #region IEditor<T> implemented
        
        T IEditor<T>.CreateObject()
        {
            return NewObject(null);
        }
        
        T IEditor<T>.CreateObject(T fromEntity)
        {
            return NewObject(null, fromEntity);
        }
        
        T IEditor<T>.CreateObject(Entity owner)
        {
            master = owner;
            return NewObject(null);
        }
        
        T IEditor<T>.CreateObject(IViewer viewer)
        {
            return NewObject(viewer);
        }
        
        T IEditor<T>.CreateObject(IViewer viewer, T fromEntity)
        {
            return NewObject(viewer, fromEntity);
        }
        
        T IEditor<T>.CreateObject(IViewer viewer, Entity owner)
        {
            master = owner;
            return NewObject(viewer);
        }

        T IEditor<T>.Edit(int id)
        {
            OnInitialize();
            try
            {
                Text = RepositoryList.Table<T>(session).Title;
                current = RepositoryList.Get<T>(session).Get(id);
                DoBeforeEditingObject();
                if (ShowDialog() == DialogResult.OK)
                {
                    session.Transaction.Commit();
                    return current;
                }
                
                session.Transaction.Rollback();
                return null;
            }
            finally
            {
                OnFinalize();
            }
        }
        
        T IEditor<T>.Edit(int id, Entity masterEntity)
        {
            master = masterEntity;
            return ((IEditor<T>)this).Edit(id);
        }
        
        #endregion
        
        protected virtual void OnInitialize() { OpenSession(); }
        protected virtual void OnFinalize() {}
        protected virtual void OnBeforeCreatingObject() { }
        protected virtual void OnBeforeCommitObject() { }
        protected virtual void OnCommitObject() { }
        protected virtual void OnAfterCommitObject() { }
        protected virtual void OnBeforeEditingObject() { }
        
        protected void Lock()
        {
            locked++;
        }
        
        protected void Unlock()
        {
            locked--;
        }
        
        void SetEnabledPrinting()
        {
            buttonPrint.Visible = Printer.Get<T>() != null;
        }
        
        void OpenSession()
        {
            session = DataHelper.OpenSession();
            session.BeginTransaction();
        }
        
        void DoBeforeCreatingObject()
        {
            Lock();
            try
            {
                OnBeforeCreatingObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        void DoBeforeCommitObject()
        {
            Lock();
            try
            {
                OnBeforeCommitObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        void DoBeforeEditingObject()
        {
            Lock();
            try
            {
                OnBeforeEditingObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        void DoAfterCommitObject()
        {
            Lock();
            try
            {
                OnAfterCommitObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        bool DoCommitObject()
        {
            DoBeforeCommitObject();
            try
            {
                current = session.Merge(current);
                OnCommitObject();
                session.Flush();
                DoAfterCommitObject();
                return true;
            }
            catch (Exception e)
            {
                ExceptionHelper.Messsage(e);
                DialogResult = DialogResult.None;
                OpenSession();
            }
            
            return false;
        }
        
        void Print()
        {
            if (DoCommitObject())
            {
                IPrinting<T> p = Printer.Get<T>();
                if (p == null)
                {
                    KryptonMessageBox.Show(Strings.PrintNotAvailable, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    p.Print(session, current);
                }
            }
        }
        
        void ButtonOKClick(object sender, EventArgs e)
        {
            DoCommitObject();
        }
        
        void ButtonPrintClick(object sender, EventArgs e)
        {
            Print();
        }
    }
}
