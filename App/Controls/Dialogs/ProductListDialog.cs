//-----------------------------------------------------------------------
// <copyright file="ProductListDialog.cs" company="Sergey Teplyashin">
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
// <date>26.06.2015</date>
// <time>10:24</time>
// <summary>Defines the ProductListDialog class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using WorkProject.Data;
    using WorkProject.Data.Entities;

    public partial class ProductListDialog : KryptonForm
    {
        readonly Dictionary<Specification, decimal> specifications;
        ISession currentSession;
        
        public ProductListDialog()
        {
            InitializeComponent();
            gridProducts.AutoGenerateColumns = false;
            buttonSelectSpec.Click += ButtonSpecificationSelect;
            specifications = new Dictionary<Specification, decimal>();
        }
        
        public IEnumerable<Specification> Specifications
        {
            get { return specifications.Keys; }
        }
        
        public bool RoundToMinOrder { get { return checkMinOrder.Checked; } }
        
        public bool AddingOnlySupplierMaterials { get { return checkSupplier.Checked; } }
        
        public decimal this[Specification specification]
        {
            get { return specifications[specification]; }
        }
        
        public bool ShowDialog(ISession session)
        {
            currentSession = session;
            foreach (Product p in session.CreateCriteria<Product>().List<Product>())
            {
                int row = gridProducts.Rows.Add();
                gridProducts[0, row].Value = p;
                gridProducts[1, row].Value = p.Specification;
                gridProducts[2, row].Value = 0;
                
                gridProducts[2, row].ReadOnly = p.Specification == null;
            }
            
            if (ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow r in gridProducts.Rows)
                {
                    decimal count = Convert.ToDecimal(r.Cells[2].Value);
                    if (count != 0)
                    {
                        specifications.Add((Specification)r.Cells[1].Value, count);
                    }
                }
                
                return true;
            }
            
            return false;
        }
        
        void ButtonSpecificationSelect(object sender, EventArgs e)
        {
            SpecificationListDialog f = new SpecificationListDialog();
            Specification spec = f.ShowDialog(currentSession, (Product)gridProducts.CurrentRow.Cells[0].Value);
            if (spec != null)
            {
                gridProducts.CurrentRow.Cells[1].Value = spec;
                gridProducts.CurrentRow.Cells[2].ReadOnly = false;
                gridProducts.CurrentRow.Cells[2].ReadOnly = false;
                gridProducts.Refresh();
            }
        }
        
        void GridProductsCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && gridProducts[e.ColumnIndex, e.RowIndex].ReadOnly)
            {
                e.CellStyle.ForeColor = Color.LightGray;
            }
            else
            {
                e.CellStyle.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
