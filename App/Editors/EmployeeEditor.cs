//-----------------------------------------------------------------------
// <copyright file="EmployeeEditor.cs" company="Sergey Teplyashin">
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
// <date>10.11.2014</date>
// <time>14:39</time>
// <summary>Defines the EmployeeEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;

    public partial class EmployeeEditor : ObjectEditor<Employee>
    {
        public EmployeeEditor()
        {
            InitializeComponent();
            ActiveControl = selectWorkPlace;
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            selectPerson.LoadEntities<Person>();
            selectPost.LoadEntities<Okpdtr>();
            selectWorkPlace.LoadEntities<Contractor>(Viewer == null ? null : Viewer.CurrentGroup as Contractor);
            comboStatus.SelectedIndex = 0;
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            selectWorkPlace.LoadEntities<Contractor>(Current.Contractor);
            textEmail.Text = Current.Email;
            selectPerson.LoadEntities<Person>(Current.Person);
            selectPost.LoadEntities<Okpdtr>(Current.Post);
            textPhone.Text = Current.Phone;
            textFax.Text = Current.Fax;
            comboStatus.SelectedIndex = (int)Current.Status;
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Contractor = selectWorkPlace.GetSelectedEntity<Contractor>();
            Current.Email = textEmail.Text.NullIfEmpty();
            Current.Person = selectPerson.GetSelectedEntity<Person>();
            Current.Post = selectPost.GetSelectedEntity<Okpdtr>();
            Current.Phone = textPhone.Text.NullIfEmpty();
            Current.Fax = textFax.Text.NullIfEmpty();
            Current.Status = (employee_status)comboStatus.SelectedIndex;
        }
    }
}
