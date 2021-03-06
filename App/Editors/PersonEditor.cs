﻿//-----------------------------------------------------------------------
// <copyright file="PersonEditor.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergey-teplyashin@yandex.ru</email>
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
// <date>08.11.2014</date>
// <time>17:06</time>
// <summary>Defines the PersonEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using NHibernate;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;
    
    public partial class PersonEditor : ObjectEditor<Person>
    {
        bool newViewName;
        bool updated;
        
        public PersonEditor()
        {
            InitializeComponent();
            ActiveControl = textSurname;
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            newViewName = true;
            selectGroup.LoadGroups<Person>(Viewer == null ? null : Viewer.CurrentGroup as GroupItem);
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            newViewName = false;
            textName.Text = Current.Name;
            textSurname.Text = Current.Surname;
            textFirstName.Text = Current.FirstName;
            textMiddleName.Text = Current.MiddleName;
            textPhone.Text = Current.Phone;
            textEmail.Text = Current.Email;
            selectGroup.LoadGroups<Person>(Current.Group);
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Name = textName.Text.NullIfEmpty();
            Current.Surname = textSurname.Text.NullIfEmpty();
            Current.FirstName = textFirstName.Text.NullIfEmpty();
            Current.MiddleName = textMiddleName.Text.NullIfEmpty();
            Current.Phone = textPhone.Text.NullIfEmpty();
            Current.Email = textEmail.Text.NullIfEmpty();
            Current.Group = selectGroup.GetSelectedEntity<GroupItem>();
        }
        
        void NameChanged(object sender, EventArgs e)
        {
            if (newViewName)
            {
                updated = true;
                try
                {
                    textName.Text = Person.GenerateStandardViewName(textSurname.Text, textFirstName.Text, textMiddleName.Text);
                }
                finally
                {
                    updated = false;
                }
            }          
        }
        
        void TextViewNameTextChanged(object sender, EventArgs e)
        {
            if (!updated)
            {
                newViewName = false;
            }          
        }
    }
}
