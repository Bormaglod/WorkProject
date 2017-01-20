//-----------------------------------------------------------------------
// <copyright file="ContractorEditor.Design.cs" company="Sergey Teplyashin">
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
// <date>05.11.2014</date>
// <time>13:13</time>
// <summary>Defines the ContractorEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    partial class ContractorEditor
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageCommon = new System.Windows.Forms.TabPage();
            this.kryptonLabel16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textWeb = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.selectBank = new WorkProject.Controls.SelectBox();
            this.selectGroup = new WorkProject.Controls.SelectBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textAccount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textFax = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textPhone = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textFullName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textShortName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pageCode = new System.Windows.Forms.TabPage();
            this.textOkpo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textOgrn = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textKpp = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textInn = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.selectOkopf = new WorkProject.Controls.SelectBox();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel14 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pageMaterial = new System.Windows.Forms.TabPage();
            this.gridMaterials = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.pgaeEmplyee = new System.Windows.Forms.TabPage();
            this.gridEmployees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.checkOurFirm = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.tabMain.SuspendLayout();
            this.pageCommon.SuspendLayout();
            this.pageCode.SuspendLayout();
            this.pageMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterials)).BeginInit();
            this.pgaeEmplyee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.pageCommon);
            this.tabMain.Controls.Add(this.pageCode);
            this.tabMain.Controls.Add(this.pageMaterial);
            this.tabMain.Controls.Add(this.pgaeEmplyee);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(571, 340);
            this.tabMain.TabIndex = 0;
            // 
            // pageCommon
            // 
            this.pageCommon.Controls.Add(this.kryptonLabel16);
            this.pageCommon.Controls.Add(this.textWeb);
            this.pageCommon.Controls.Add(this.selectBank);
            this.pageCommon.Controls.Add(this.selectGroup);
            this.pageCommon.Controls.Add(this.kryptonLabel10);
            this.pageCommon.Controls.Add(this.textEmail);
            this.pageCommon.Controls.Add(this.kryptonLabel9);
            this.pageCommon.Controls.Add(this.textAccount);
            this.pageCommon.Controls.Add(this.kryptonLabel8);
            this.pageCommon.Controls.Add(this.kryptonLabel7);
            this.pageCommon.Controls.Add(this.kryptonLabel6);
            this.pageCommon.Controls.Add(this.textFax);
            this.pageCommon.Controls.Add(this.textPhone);
            this.pageCommon.Controls.Add(this.textAddress);
            this.pageCommon.Controls.Add(this.textFullName);
            this.pageCommon.Controls.Add(this.textShortName);
            this.pageCommon.Controls.Add(this.textName);
            this.pageCommon.Controls.Add(this.kryptonLabel5);
            this.pageCommon.Controls.Add(this.kryptonLabel4);
            this.pageCommon.Controls.Add(this.kryptonLabel3);
            this.pageCommon.Controls.Add(this.kryptonLabel2);
            this.pageCommon.Controls.Add(this.kryptonLabel1);
            this.pageCommon.Location = new System.Drawing.Point(4, 22);
            this.pageCommon.Name = "pageCommon";
            this.pageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.pageCommon.Size = new System.Drawing.Size(563, 314);
            this.pageCommon.TabIndex = 0;
            this.pageCommon.Text = "О фирме";
            this.pageCommon.UseVisualStyleBackColor = true;
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel16.Location = new System.Drawing.Point(6, 235);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel16.TabIndex = 14;
            this.kryptonLabel16.Values.Text = "Web";
            // 
            // textWeb
            // 
            this.textWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWeb.Location = new System.Drawing.Point(155, 235);
            this.textWeb.Name = "textWeb";
            this.textWeb.Size = new System.Drawing.Size(402, 20);
            this.textWeb.TabIndex = 15;
            // 
            // selectBank
            // 
            this.selectBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBank.Location = new System.Drawing.Point(346, 288);
            this.selectBank.Name = "selectBank";
            this.selectBank.Size = new System.Drawing.Size(211, 21);
            this.selectBank.TabIndex = 21;
            // 
            // selectGroup
            // 
            this.selectGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectGroup.Location = new System.Drawing.Point(155, 261);
            this.selectGroup.Name = "selectGroup";
            this.selectGroup.Size = new System.Drawing.Size(171, 21);
            this.selectGroup.TabIndex = 17;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel10.Location = new System.Drawing.Point(323, 288);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(17, 20);
            this.kryptonLabel10.TabIndex = 20;
            this.kryptonLabel10.Values.Text = "в";
            // 
            // textEmail
            // 
            this.textEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEmail.Location = new System.Drawing.Point(155, 209);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(402, 20);
            this.textEmail.TabIndex = 13;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel9.Location = new System.Drawing.Point(6, 209);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel9.TabIndex = 12;
            this.kryptonLabel9.Values.Text = "Эл. почта";
            // 
            // textAccount
            // 
            this.textAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textAccount.Location = new System.Drawing.Point(155, 288);
            this.textAccount.Name = "textAccount";
            this.textAccount.Size = new System.Drawing.Size(162, 20);
            this.textAccount.TabIndex = 19;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel8.Location = new System.Drawing.Point(6, 287);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(99, 20);
            this.kryptonLabel8.TabIndex = 18;
            this.kryptonLabel8.Values.Text = "Расчетный счет";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel7.Location = new System.Drawing.Point(6, 261);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel7.TabIndex = 16;
            this.kryptonLabel7.Values.Text = "Группа";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel6.Location = new System.Drawing.Point(332, 183);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel6.TabIndex = 10;
            this.kryptonLabel6.Values.Text = "Факс";
            // 
            // textFax
            // 
            this.textFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textFax.Location = new System.Drawing.Point(376, 183);
            this.textFax.Name = "textFax";
            this.textFax.Size = new System.Drawing.Size(181, 20);
            this.textFax.TabIndex = 11;
            // 
            // textPhone
            // 
            this.textPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textPhone.Location = new System.Drawing.Point(155, 183);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(171, 20);
            this.textPhone.TabIndex = 9;
            // 
            // textAddress
            // 
            this.textAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddress.Location = new System.Drawing.Point(155, 84);
            this.textAddress.Multiline = true;
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(402, 93);
            this.textAddress.TabIndex = 7;
            // 
            // textFullName
            // 
            this.textFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFullName.Location = new System.Drawing.Point(155, 58);
            this.textFullName.Name = "textFullName";
            this.textFullName.Size = new System.Drawing.Size(402, 20);
            this.textFullName.TabIndex = 5;
            // 
            // textShortName
            // 
            this.textShortName.Location = new System.Drawing.Point(155, 32);
            this.textShortName.Name = "textShortName";
            this.textShortName.Size = new System.Drawing.Size(229, 20);
            this.textShortName.TabIndex = 3;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(155, 6);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(151, 20);
            this.textName.TabIndex = 1;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel5.Location = new System.Drawing.Point(6, 183);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Телефон";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(6, 84);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Адрес";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 58);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Полное наименование";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 32);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(143, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Краткое наименование";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 6);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Наименование";
            // 
            // pageCode
            // 
            this.pageCode.Controls.Add(this.textOkpo);
            this.pageCode.Controls.Add(this.textOgrn);
            this.pageCode.Controls.Add(this.textKpp);
            this.pageCode.Controls.Add(this.textInn);
            this.pageCode.Controls.Add(this.selectOkopf);
            this.pageCode.Controls.Add(this.kryptonLabel15);
            this.pageCode.Controls.Add(this.kryptonLabel14);
            this.pageCode.Controls.Add(this.kryptonLabel13);
            this.pageCode.Controls.Add(this.kryptonLabel12);
            this.pageCode.Controls.Add(this.kryptonLabel11);
            this.pageCode.Location = new System.Drawing.Point(4, 22);
            this.pageCode.Name = "pageCode";
            this.pageCode.Padding = new System.Windows.Forms.Padding(3);
            this.pageCode.Size = new System.Drawing.Size(563, 242);
            this.pageCode.TabIndex = 1;
            this.pageCode.Text = "Коды";
            this.pageCode.UseVisualStyleBackColor = true;
            // 
            // textOkpo
            // 
            this.textOkpo.Location = new System.Drawing.Point(65, 111);
            this.textOkpo.Name = "textOkpo";
            this.textOkpo.Size = new System.Drawing.Size(100, 20);
            this.textOkpo.TabIndex = 9;
            // 
            // textOgrn
            // 
            this.textOgrn.Location = new System.Drawing.Point(65, 85);
            this.textOgrn.Name = "textOgrn";
            this.textOgrn.Size = new System.Drawing.Size(175, 20);
            this.textOgrn.TabIndex = 7;
            // 
            // textKpp
            // 
            this.textKpp.Location = new System.Drawing.Point(65, 59);
            this.textKpp.Name = "textKpp";
            this.textKpp.Size = new System.Drawing.Size(100, 20);
            this.textKpp.TabIndex = 5;
            // 
            // textInn
            // 
            this.textInn.Location = new System.Drawing.Point(65, 33);
            this.textInn.Name = "textInn";
            this.textInn.Size = new System.Drawing.Size(100, 20);
            this.textInn.TabIndex = 3;
            // 
            // selectOkopf
            // 
            this.selectOkopf.Location = new System.Drawing.Point(65, 6);
            this.selectOkopf.Name = "selectOkopf";
            this.selectOkopf.Size = new System.Drawing.Size(314, 21);
            this.selectOkopf.TabIndex = 1;
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(6, 111);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel15.TabIndex = 8;
            this.kryptonLabel15.Values.Text = "ОКПО";
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(6, 85);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(41, 20);
            this.kryptonLabel14.TabIndex = 6;
            this.kryptonLabel14.Values.Text = "ОГРН";
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(6, 59);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(35, 20);
            this.kryptonLabel13.TabIndex = 4;
            this.kryptonLabel13.Values.Text = "КПП";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(6, 33);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(37, 20);
            this.kryptonLabel12.TabIndex = 2;
            this.kryptonLabel12.Values.Text = "ИНН";
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(6, 6);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel11.TabIndex = 0;
            this.kryptonLabel11.Values.Text = "ОКОПФ";
            // 
            // pageMaterial
            // 
            this.pageMaterial.Controls.Add(this.gridMaterials);
            this.pageMaterial.Location = new System.Drawing.Point(4, 22);
            this.pageMaterial.Name = "pageMaterial";
            this.pageMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.pageMaterial.Size = new System.Drawing.Size(563, 242);
            this.pageMaterial.TabIndex = 2;
            this.pageMaterial.Text = "Услуги/материалы";
            this.pageMaterial.UseVisualStyleBackColor = true;
            // 
            // gridMaterials
            // 
            this.gridMaterials.AllowUserToAddRows = false;
            this.gridMaterials.AllowUserToDeleteRows = false;
            this.gridMaterials.AllowUserToResizeRows = false;
            this.gridMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMaterials.Location = new System.Drawing.Point(6, 6);
            this.gridMaterials.MultiSelect = false;
            this.gridMaterials.Name = "gridMaterials";
            this.gridMaterials.ReadOnly = true;
            this.gridMaterials.RowHeadersVisible = false;
            this.gridMaterials.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMaterials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMaterials.Size = new System.Drawing.Size(551, 230);
            this.gridMaterials.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
            this.gridMaterials.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.gridMaterials.TabIndex = 0;
            // 
            // pgaeEmplyee
            // 
            this.pgaeEmplyee.Controls.Add(this.gridEmployees);
            this.pgaeEmplyee.Location = new System.Drawing.Point(4, 22);
            this.pgaeEmplyee.Name = "pgaeEmplyee";
            this.pgaeEmplyee.Padding = new System.Windows.Forms.Padding(3);
            this.pgaeEmplyee.Size = new System.Drawing.Size(563, 242);
            this.pgaeEmplyee.TabIndex = 3;
            this.pgaeEmplyee.Text = "Сотрудники";
            this.pgaeEmplyee.UseVisualStyleBackColor = true;
            // 
            // gridEmployees
            // 
            this.gridEmployees.AllowUserToAddRows = false;
            this.gridEmployees.AllowUserToDeleteRows = false;
            this.gridEmployees.AllowUserToResizeRows = false;
            this.gridEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmployees.Location = new System.Drawing.Point(6, 6);
            this.gridEmployees.MultiSelect = false;
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.ReadOnly = true;
            this.gridEmployees.RowHeadersVisible = false;
            this.gridEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmployees.Size = new System.Drawing.Size(551, 230);
            this.gridEmployees.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
            this.gridEmployees.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.gridEmployees.TabIndex = 0;
            // 
            // checkOurFirm
            // 
            this.checkOurFirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkOurFirm.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkOurFirm.Location = new System.Drawing.Point(12, 358);
            this.checkOurFirm.Name = "checkOurFirm";
            this.checkOurFirm.Size = new System.Drawing.Size(96, 20);
            this.checkOurFirm.TabIndex = 1;
            this.checkOurFirm.Text = "Наша фирма";
            this.checkOurFirm.Values.Text = "Наша фирма";
            // 
            // ContractorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 436);
            this.Controls.Add(this.checkOurFirm);
            this.Controls.Add(this.tabMain);
            this.MinimumSize = new System.Drawing.Size(603, 397);
            this.Name = "ContractorEditor";
            this.Text = "ContractorEditor";
            this.Controls.SetChildIndex(this.tabMain, 0);
            this.Controls.SetChildIndex(this.checkOurFirm, 0);
            this.tabMain.ResumeLayout(false);
            this.pageCommon.ResumeLayout(false);
            this.pageCommon.PerformLayout();
            this.pageCode.ResumeLayout(false);
            this.pageCode.PerformLayout();
            this.pageMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterials)).EndInit();
            this.pgaeEmplyee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridMaterials;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkOurFirm;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel13;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel14;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private WorkProject.Controls.SelectBox selectOkopf;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textInn;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textKpp;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textOgrn;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textOkpo;
        private WorkProject.Controls.SelectBox selectGroup;
        private WorkProject.Controls.SelectBox selectBank;
        private System.Windows.Forms.TabPage pgaeEmplyee;
        private System.Windows.Forms.TabPage pageMaterial;
        private System.Windows.Forms.TabPage pageCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textShortName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textFullName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textPhone;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textFax;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textAccount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private System.Windows.Forms.TabPage pageCommon;
        private System.Windows.Forms.TabControl tabMain;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel16;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textWeb;
    }
}
