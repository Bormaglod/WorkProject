//-----------------------------------------------------------------------
// <copyright file=SpecificationListDialog.cs company="Sergey Teplyashin">
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
// <date>11.05.2016</date>
// <time>9:30</time>
// <summary>Defines the SpecificationListDialog class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using NHibernate.Criterion;
    using WorkProject.Data.Entities;

    public partial class SpecificationListDialog : KryptonForm
    {
        public SpecificationListDialog()
        {
            InitializeComponent();
        }
        
        public Specification ShowDialog(ISession session, Product product)
        {
            IEnumerable<Specification> list = session.CreateCriteria<Specification>()
                .Add(Restrictions.Eq("Product", product))
                .List<Specification>();
            
            foreach (Specification item in list)
            {
                int row = gridSpecifications.Rows.Add();
                gridSpecifications[0, row].Value = item.DateApproval.ToString();
                gridSpecifications[1, row].Value = item.ToString();
                gridSpecifications[2, row].Value = item.IsDefault;
                gridSpecifications.Rows[row].Tag = item;
            }
            
            UpdateButtons();
            
            if (ShowDialog() == DialogResult.OK)
            {
                if (gridSpecifications.CurrentRow != null)
                {
                    return (Specification)gridSpecifications.CurrentRow.Tag;
                }
            }
            
            return null;
        }
        
        void UpdateButtons()
        {
            buttonOk.Enabled = gridSpecifications.CurrentRow != null;
        }
        
        void GridSpecificationsDoubleClick(object sender, EventArgs e)
        {
            buttonOk.PerformClick();
        }
        
        void GridSpecificationsSelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
