//-----------------------------------------------------------------------
// <copyright file="OkpdtrEditor.cs" company="Sergey Teplyashin">
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
// <date>07.11.2014</date>
// <time>21:33</time>
// <summary>Defines the OkpdtrEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using NHibernate;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;
    
    public partial class OkpdtrEditor : ObjectEditor<Okpdtr>
    {
        public OkpdtrEditor()
        {
            InitializeComponent();
            ActiveControl = textCode;
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textCode.Text = Current.Code.ToString();
            textName.Text = Current.Name;
            textViewName.Text = Current.ViewName;
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Code = textCode.Text.ToDecimal();
            Current.Name = textName.Text.NullIfEmpty();
            Current.ViewName = textViewName.Text.NullIfEmpty();
        }
    }
}
