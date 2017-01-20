//-----------------------------------------------------------------------
// <copyright file="SupplierEditor.cs" company="Sergey Teplyashin">
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
// <date>14.11.2014</date>
// <time>9:05</time>
// <summary>Defines the SupplierEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using NHibernate;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;

    public partial class SupplierEditor : ObjectEditor<Supplier>
    {
        public SupplierEditor()
        {
            InitializeComponent();
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            selectContractor.LoadEntities<Contractor>(Viewer == null ? null : Viewer.CurrentGroup as Contractor);
            selectMaterial.LoadEntities<Material>();
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            selectContractor.LoadEntities<Contractor>(Current.Contractor);
            selectMaterial.LoadEntities<Material>(Current.Material);
            numericPrice.Value = Current.Price.GetValueOrDefault();
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Contractor = selectContractor.GetSelectedEntity<Contractor>();
            Current.Material = selectMaterial.GetSelectedEntity<Material>();
            Current.Price = numericPrice.Value.Default();
        }
        
        void ButtonFillPriceClick(object sender, EventArgs e)
        {
            Material m = selectMaterial.GetSelectedEntity<Material>();
            if (m != null)
            {
                numericPrice.Value = m.Price;
            }
        }
    }
}
