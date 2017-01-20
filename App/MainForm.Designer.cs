//-----------------------------------------------------------------------
// <copyright file="MainForm.Design.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2014 Sergey Teplyashin. All rights reserved.
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
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
            this.qRibbonApplicationButton1 = new Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton();
            this.qRibbon1 = new Qios.DevSuite.Components.Ribbon.QRibbon();
            this.qRibbonPage1 = new Qios.DevSuite.Components.Ribbon.QRibbonPage();
            this.qRibbonPanel2 = new Qios.DevSuite.Components.Ribbon.QRibbonPanel();
            this.qItemMeasurement = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qItemOkopf = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qItemOkpdtr = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemPerson = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonPanel1 = new Qios.DevSuite.Components.Ribbon.QRibbonPanel();
            this.qRibbonBank = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemContractor = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemTax = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemEmployee = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemSupplier = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonPanel3 = new Qios.DevSuite.Components.Ribbon.QRibbonPanel();
            this.qRibbonItemMaterial = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemOperation = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemProduct = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonPage2 = new Qios.DevSuite.Components.Ribbon.QRibbonPage();
            this.qRibbonPanel4 = new Qios.DevSuite.Components.Ribbon.QRibbonPanel();
            this.qRibbonItemInputInvoice = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemOutputInvoice = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qCompositeSeparator1 = new Qios.DevSuite.Components.QCompositeSeparator();
            this.qRibbonWriteOff = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonPanel5 = new Qios.DevSuite.Components.Ribbon.QRibbonPanel();
            this.qRibbonItemMovingMaterials = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonPage3 = new Qios.DevSuite.Components.Ribbon.QRibbonPage();
            this.qRibbonPanel6 = new Qios.DevSuite.Components.Ribbon.QRibbonPanel();
            this.qRibbonItemPlan = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.qRibbonItemRequest = new Qios.DevSuite.Components.Ribbon.QRibbonItem();
            this.viewer = new WorkProject.Controls.MainPanel();
            this.qGlobalColorSchemeManager1 = new Qios.DevSuite.Components.QGlobalColorSchemeManager(this.components);
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbon1)).BeginInit();
            this.qRibbon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonPage3)).BeginInit();
            this.SuspendLayout();
            // 
            // qRibbonCaption1
            // 
            this.qRibbonCaption1.ApplicationButton = this.qRibbonApplicationButton1;
            this.qRibbonCaption1.Configuration.IconConfiguration.Visible = Qios.DevSuite.Components.QTristateBool.False;
            this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
            this.qRibbonCaption1.Name = "qRibbonCaption1";
            this.qRibbonCaption1.Size = new System.Drawing.Size(926, 28);
            this.qRibbonCaption1.TabIndex = 0;
            this.qRibbonCaption1.Text = "Work Project";
            // 
            // qRibbon1
            // 
            this.qRibbon1.ActiveTabPage = this.qRibbonPage1;
            this.qRibbon1.Controls.Add(this.qRibbonPage1);
            this.qRibbon1.Controls.Add(this.qRibbonPage2);
            this.qRibbon1.Controls.Add(this.qRibbonPage3);
            this.qRibbon1.Dock = System.Windows.Forms.DockStyle.Top;
            this.qRibbon1.Location = new System.Drawing.Point(0, 28);
            this.qRibbon1.Name = "qRibbon1";
            this.qRibbon1.PersistGuid = new System.Guid("c55b61a0-ec1c-40ba-8e89-f4ff918ecad7");
            this.qRibbon1.Size = new System.Drawing.Size(926, 135);
            this.qRibbon1.TabIndex = 1;
            this.qRibbon1.Text = "qRibbon1";
            // 
            // qRibbonPage1
            // 
            this.qRibbonPage1.ButtonOrder = 0;
            this.qRibbonPage1.Items.Add(this.qRibbonPanel2);
            this.qRibbonPage1.Items.Add(this.qRibbonPanel1);
            this.qRibbonPage1.Items.Add(this.qRibbonPanel3);
            this.qRibbonPage1.Location = new System.Drawing.Point(2, 31);
            this.qRibbonPage1.Name = "qRibbonPage1";
            this.qRibbonPage1.PersistGuid = new System.Guid("5641dabd-f7c7-45ad-81e8-fec0da6fe404");
            this.qRibbonPage1.Size = new System.Drawing.Size(920, 100);
            this.qRibbonPage1.Text = "Справочники";
            // 
            // qRibbonPanel2
            // 
            this.qRibbonPanel2.Configuration.CaptionConfiguration.Visible = Qios.DevSuite.Components.QTristateBool.True;
            this.qRibbonPanel2.Items.Add(this.qItemMeasurement);
            this.qRibbonPanel2.Items.Add(this.qItemOkopf);
            this.qRibbonPanel2.Items.Add(this.qItemOkpdtr);
            this.qRibbonPanel2.Items.Add(this.qRibbonItemPerson);
            this.qRibbonPanel2.Title = "Общие";
            // 
            // qItemMeasurement
            // 
            this.qItemMeasurement.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qItemMeasurement.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qItemMeasurement.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qItemMeasurement.Configuration.TitleConfiguration.MaximumSize = new System.Drawing.Size(100, 0);
            this.qItemMeasurement.Configuration.TitleConfiguration.WrapText = true;
            this.qItemMeasurement.Icon = ((System.Drawing.Icon)(resources.GetObject("qItemMeasurement.Icon")));
            this.qItemMeasurement.Title = "Еденицы измерения";
            this.qItemMeasurement.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QItemMeasurementItemActivated);
            // 
            // qItemOkopf
            // 
            this.qItemOkopf.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qItemOkopf.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qItemOkopf.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qItemOkopf.Icon = ((System.Drawing.Icon)(resources.GetObject("qItemOkopf.Icon")));
            this.qItemOkopf.Title = "ОКОПФ";
            this.qItemOkopf.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QItemOkopfItemActivated);
            // 
            // qItemOkpdtr
            // 
            this.qItemOkpdtr.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qItemOkpdtr.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qItemOkpdtr.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qItemOkpdtr.Icon = ((System.Drawing.Icon)(resources.GetObject("qItemOkpdtr.Icon")));
            this.qItemOkpdtr.Title = "ОКПДТР";
            this.qItemOkpdtr.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QItemOkpdtrItemActivated);
            // 
            // qRibbonItemPerson
            // 
            this.qRibbonItemPerson.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemPerson.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemPerson.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemPerson.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemPerson.Icon")));
            this.qRibbonItemPerson.Title = "Физ. лица";
            this.qRibbonItemPerson.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QItemPersonItemActivated);
            // 
            // qRibbonPanel1
            // 
            this.qRibbonPanel1.Items.Add(this.qRibbonBank);
            this.qRibbonPanel1.Items.Add(this.qRibbonItemContractor);
            this.qRibbonPanel1.Items.Add(this.qRibbonItemTax);
            this.qRibbonPanel1.Items.Add(this.qRibbonItemEmployee);
            this.qRibbonPanel1.Items.Add(this.qRibbonItemSupplier);
            this.qRibbonPanel1.Title = "Предприятие";
            // 
            // qRibbonBank
            // 
            this.qRibbonBank.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonBank.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonBank.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonBank.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonBank.Icon")));
            this.qRibbonBank.Title = "Банки";
            this.qRibbonBank.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QItemBankItemActivated);
            // 
            // qRibbonItemContractor
            // 
            this.qRibbonItemContractor.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemContractor.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemContractor.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemContractor.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemContractor.Icon")));
            this.qRibbonItemContractor.Title = "Контрагенты";
            this.qRibbonItemContractor.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QItemContractorItemActivated);
            // 
            // qRibbonItemTax
            // 
            this.qRibbonItemTax.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemTax.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemTax.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemTax.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemTax.Icon")));
            this.qRibbonItemTax.Title = "Отчисления";
            this.qRibbonItemTax.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemTaxItemActivated);
            // 
            // qRibbonItemEmployee
            // 
            this.qRibbonItemEmployee.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemEmployee.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemEmployee.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemEmployee.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemEmployee.Icon")));
            this.qRibbonItemEmployee.Title = "Сотрудники";
            this.qRibbonItemEmployee.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemEmployeeItemActivated);
            // 
            // qRibbonItemSupplier
            // 
            this.qRibbonItemSupplier.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemSupplier.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemSupplier.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemSupplier.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemSupplier.Icon")));
            this.qRibbonItemSupplier.Title = "Поставщики";
            this.qRibbonItemSupplier.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemSupplierItemActivated);
            // 
            // qRibbonPanel3
            // 
            this.qRibbonPanel3.Items.Add(this.qRibbonItemMaterial);
            this.qRibbonPanel3.Items.Add(this.qRibbonItemOperation);
            this.qRibbonPanel3.Items.Add(this.qRibbonItemProduct);
            this.qRibbonPanel3.Title = "Производство";
            // 
            // qRibbonItemMaterial
            // 
            this.qRibbonItemMaterial.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemMaterial.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemMaterial.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemMaterial.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemMaterial.Icon")));
            this.qRibbonItemMaterial.Title = "Материалы";
            this.qRibbonItemMaterial.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QItemMaterialItemActivated);
            // 
            // qRibbonItemOperation
            // 
            this.qRibbonItemOperation.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemOperation.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemOperation.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemOperation.Configuration.TitleConfiguration.MaximumSize = new System.Drawing.Size(110, 0);
            this.qRibbonItemOperation.Configuration.TitleConfiguration.WrapText = true;
            this.qRibbonItemOperation.Icon = global::WorkProject.Resources.tools_sign;
            this.qRibbonItemOperation.Title = "Технологические операции";
            this.qRibbonItemOperation.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemOperationItemActivated);
            // 
            // qRibbonItemProduct
            // 
            this.qRibbonItemProduct.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemProduct.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemProduct.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemProduct.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemProduct.Icon")));
            this.qRibbonItemProduct.Title = "Изделия";
            this.qRibbonItemProduct.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemProductItemActivated);
            // 
            // qRibbonPage2
            // 
            this.qRibbonPage2.ButtonOrder = 1;
            this.qRibbonPage2.Items.Add(this.qRibbonPanel4);
            this.qRibbonPage2.Items.Add(this.qRibbonPanel5);
            this.qRibbonPage2.Location = new System.Drawing.Point(2, 31);
            this.qRibbonPage2.Name = "qRibbonPage2";
            this.qRibbonPage2.PersistGuid = new System.Guid("76ed0676-1c15-47b3-aded-076c142c7ec7");
            this.qRibbonPage2.Size = new System.Drawing.Size(920, 100);
            this.qRibbonPage2.Text = "Склад";
            // 
            // qRibbonPanel4
            // 
            this.qRibbonPanel4.Items.Add(this.qRibbonItemInputInvoice);
            this.qRibbonPanel4.Items.Add(this.qRibbonItemOutputInvoice);
            this.qRibbonPanel4.Items.Add(this.qCompositeSeparator1);
            this.qRibbonPanel4.Items.Add(this.qRibbonWriteOff);
            this.qRibbonPanel4.Title = "Документы";
            // 
            // qRibbonItemInputInvoice
            // 
            this.qRibbonItemInputInvoice.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemInputInvoice.Configuration.TitleConfiguration.MaximumSize = new System.Drawing.Size(100, 0);
            this.qRibbonItemInputInvoice.Configuration.TitleConfiguration.WrapText = true;
            this.qRibbonItemInputInvoice.Title = "Приходная накладная";
            this.qRibbonItemInputInvoice.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemInputInvoiceItemActivated);
            // 
            // qRibbonItemOutputInvoice
            // 
            this.qRibbonItemOutputInvoice.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemOutputInvoice.Configuration.TitleConfiguration.MaximumSize = new System.Drawing.Size(100, 0);
            this.qRibbonItemOutputInvoice.Configuration.TitleConfiguration.WrapText = true;
            this.qRibbonItemOutputInvoice.Title = "Расходная накладная";
            this.qRibbonItemOutputInvoice.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemOutputInvoiceItemActivated);
            // 
            // qRibbonWriteOff
            // 
            this.qRibbonWriteOff.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonWriteOff.Configuration.TitleConfiguration.MaximumSize = new System.Drawing.Size(100, 0);
            this.qRibbonWriteOff.Configuration.TitleConfiguration.WrapText = true;
            this.qRibbonWriteOff.Title = "Списание материалов";
            // 
            // qRibbonPanel5
            // 
            this.qRibbonPanel5.Items.Add(this.qRibbonItemMovingMaterials);
            this.qRibbonPanel5.Title = "Отчеты";
            // 
            // qRibbonItemMovingMaterials
            // 
            this.qRibbonItemMovingMaterials.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered;
            this.qRibbonItemMovingMaterials.Configuration.TitleConfiguration.MaximumSize = new System.Drawing.Size(100, 0);
            this.qRibbonItemMovingMaterials.Configuration.TitleConfiguration.WrapText = true;
            this.qRibbonItemMovingMaterials.Title = "Движение материалов";
            // 
            // qRibbonPage3
            // 
            this.qRibbonPage3.ButtonOrder = 2;
            this.qRibbonPage3.Items.Add(this.qRibbonPanel6);
            this.qRibbonPage3.Location = new System.Drawing.Point(2, 31);
            this.qRibbonPage3.Name = "qRibbonPage3";
            this.qRibbonPage3.PersistGuid = new System.Guid("1dda3610-b820-46c4-8fb9-6c94ba61afb1");
            this.qRibbonPage3.Size = new System.Drawing.Size(920, 100);
            this.qRibbonPage3.Text = "Производство";
            // 
            // qRibbonPanel6
            // 
            this.qRibbonPanel6.Items.Add(this.qRibbonItemPlan);
            this.qRibbonPanel6.Items.Add(this.qRibbonItemRequest);
            this.qRibbonPanel6.Title = "Подготовка";
            // 
            // qRibbonItemPlan
            // 
            this.qRibbonItemPlan.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemPlan.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemPlan.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemPlan.Icon")));
            this.qRibbonItemPlan.Title = "План";
            // 
            // qRibbonItemRequest
            // 
            this.qRibbonItemRequest.Configuration.Direction = Qios.DevSuite.Components.QPartDirection.Vertical;
            this.qRibbonItemRequest.Configuration.IconConfiguration.IconSize = new System.Drawing.Size(32, 32);
            this.qRibbonItemRequest.Icon = ((System.Drawing.Icon)(resources.GetObject("qRibbonItemRequest.Icon")));
            this.qRibbonItemRequest.Title = "Заявки";
            this.qRibbonItemRequest.ItemActivated += new Qios.DevSuite.Components.QCompositeEventHandler(this.QRibbonItemRequestItemActivated);
            // 
            // viewer
            // 
            this.viewer.Location = new System.Drawing.Point(0, 163);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(926, 362);
            this.viewer.TabIndex = 2;
            this.viewer.ViewWindow = WorkProject.Controls.ViewWindow.Company;
            // 
            // qGlobalColorSchemeManager1
            // 
            this.qGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue";
            this.qGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 525);
            this.Controls.Add(this.viewer);
            this.Controls.Add(this.qRibbon1);
            this.Controls.Add(this.qRibbonCaption1);
            this.Name = "MainForm";
            this.Text = "Work Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbon1)).EndInit();
            this.qRibbon1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonPage3)).EndInit();
            this.ResumeLayout(false);

        }
        private WorkProject.Controls.MainPanel viewer;
        private Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton qRibbonApplicationButton1;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemRequest;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemPlan;
        private Qios.DevSuite.Components.Ribbon.QRibbonPanel qRibbonPanel6;
        private Qios.DevSuite.Components.Ribbon.QRibbonPage qRibbonPage3;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemMovingMaterials;
        private Qios.DevSuite.Components.Ribbon.QRibbonPanel qRibbonPanel5;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemOutputInvoice;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemInputInvoice;
        private Qios.DevSuite.Components.Ribbon.QRibbonPanel qRibbonPanel4;
        private Qios.DevSuite.Components.Ribbon.QRibbonPage qRibbonPage2;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemProduct;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemOperation;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemSupplier;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemEmployee;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemTax;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemMaterial;
        private Qios.DevSuite.Components.Ribbon.QRibbonPanel qRibbonPanel3;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemContractor;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonBank;
        private Qios.DevSuite.Components.Ribbon.QRibbonPanel qRibbonPanel1;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonItemPerson;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qItemOkpdtr;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qItemOkopf;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qItemMeasurement;
        private Qios.DevSuite.Components.Ribbon.QRibbonPanel qRibbonPanel2;
        private Qios.DevSuite.Components.Ribbon.QRibbonPage qRibbonPage1;
        private Qios.DevSuite.Components.Ribbon.QRibbon qRibbon1;
        private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;
        private Qios.DevSuite.Components.QGlobalColorSchemeManager qGlobalColorSchemeManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private Qios.DevSuite.Components.QCompositeSeparator qCompositeSeparator1;
        private Qios.DevSuite.Components.Ribbon.QRibbonItem qRibbonWriteOff;
    }
}
