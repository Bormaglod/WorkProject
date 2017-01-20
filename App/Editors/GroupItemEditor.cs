//-----------------------------------------------------------------------
// <copyright file="GroupItemEditor.cs" company="Sergey Teplyashin">
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
// <date>07.11.2014</date>
// <time>9:50</time>
// <summary>Defines the GroupItemEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using System.Linq;
    using NHibernate;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;

    public partial class GroupItemEditor : ObjectEditor<GroupItem>
    {
        public GroupItemEditor()
        {
            InitializeComponent();
            ActiveControl = textName;
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            Current.Table = (TableProperty)MasterEntity;
            comboParent.Items.AddRange(Current.Table.Groups.ToArray());
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Name  = textName.Text.NullIfEmpty();
            if (comboParent.SelectedItem == null)
            {
                Current.Parent_Id = null;
            }
            else
            {
                Current.Parent_Id = ((GroupItem)comboParent.SelectedItem).Id;
            }
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textName.Text = Current.Name;
            comboParent.Items.AddRange(Current.Table.Groups.Where(x => x.Id != Current.Id).ToArray());
            if (Current.Parent_Id.HasValue)
            {
                comboParent.SelectedItem = Current.Table.Groups.FirstOrDefault(x => x.Id == Current.Parent_Id.Value);
            }
        }
        
        void ButtonClearClick(object sender, EventArgs e)
        {
            comboParent.SelectedItem = null;
        }
    }
}
