//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Sergey Teplyashin">
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
// <date>29.08.2014</date>
// <time>12:41</time>
// <summary>Defines the MainForm class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject
{
    using System;
    using Qios.DevSuite.Components;
    using Qios.DevSuite.Components.Ribbon;
    using WorkProject.Data.Entities;

    public partial class MainForm : QRibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.qRibbonApplicationButton1.CustomChildWindow = new MenuMainForm();
        }
        
        void QItemMeasurementItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Measurement>();
        }
        
        void QItemBankItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Bank>();
        }
        
        void QItemContractorItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Contractor>();
        }
        
        void QItemMaterialItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Material>();
        }
        
        void QItemPersonItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Person>();
        }
        
        void QItemOkopfItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Okopf>();
        }
        
        void QItemOkpdtrItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Okpdtr>();
        }
        
        void QRibbonItemTaxItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Tax>();
        }
        
        void QRibbonItemEmployeeItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Employee, Contractor>();
        }
        
        void QRibbonItemSupplierItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Supplier, Contractor>();
        }
        
        void QRibbonItemOperationItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Operation>();
        }
        
        void QRibbonItemProductItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Product, Specification>();
        }
        
        void QRibbonItemInputInvoiceItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<InvoiceIncome>();
        }
        
        void QRibbonItemOutputInvoiceItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<InvoiceExpense>();
        }
        
        void QRibbonItemRequestItemActivated(object sender, QCompositeEventArgs e)
        {
            viewer.Fill<Proposal>();
        }
        
        void MainFormFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Data.DataHelper.Settings.Save();
        }
    }
}
