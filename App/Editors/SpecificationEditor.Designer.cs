//-----------------------------------------------------------------------
// <copyright file="SpecificationEditor.Design.cs" company="Sergey Teplyashin">
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
// <time>13:52</time>
// <summary>Defines the SpecificationEditor class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Editors
{
    partial class SpecificationEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dateSpec = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.textComment = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.numericProfit = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.numericProfitPercent = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.numericPrice = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.comboCalcMethod = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.checkProfit = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.checkProfitPercent = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.checkPrice = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageCommon = new System.Windows.Forms.TabPage();
            this.checkTaxValue = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.comboTaxValue = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.textSumma = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textTaxSumma = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textCost = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pageCalculation = new System.Windows.Forms.TabPage();
            this.gridCalc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.checkDefault = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.ColumnCode = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ColumnName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ColumnSumma = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.comboCalcMethod)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.pageCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboTaxValue)).BeginInit();
            this.pageCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCalc)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 6);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel1.TabIndex = 102;
            this.kryptonLabel1.Values.Text = "Наименование";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 32);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(165, 20);
            this.kryptonLabel2.TabIndex = 103;
            this.kryptonLabel2.Values.Text = "Дата создания/утвержения";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 56);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel3.TabIndex = 104;
            this.kryptonLabel3.Values.Text = "Комментарий";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel4.Location = new System.Drawing.Point(6, 104);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel4.TabIndex = 105;
            this.kryptonLabel4.Values.Text = "Себестоимость";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel5.Location = new System.Drawing.Point(6, 157);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel5.TabIndex = 106;
            this.kryptonLabel5.Values.Text = "Прибыль";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel6.Location = new System.Drawing.Point(6, 183);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel6.TabIndex = 107;
            this.kryptonLabel6.Values.Text = "Цена без НДС";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel7.Location = new System.Drawing.Point(6, 131);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel7.TabIndex = 108;
            this.kryptonLabel7.Values.Text = "Прибыль (%)";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel8.Location = new System.Drawing.Point(6, 77);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(155, 20);
            this.kryptonLabel8.TabIndex = 109;
            this.kryptonLabel8.Values.Text = "Способ расчета прибыли";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(177, 6);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(351, 20);
            this.textName.TabIndex = 0;
            // 
            // dateSpec
            // 
            this.dateSpec.Location = new System.Drawing.Point(177, 32);
            this.dateSpec.Name = "dateSpec";
            this.dateSpec.Size = new System.Drawing.Size(162, 21);
            this.dateSpec.TabIndex = 1;
            // 
            // textComment
            // 
            this.textComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textComment.Location = new System.Drawing.Point(177, 56);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.Size = new System.Drawing.Size(351, 20);
            this.textComment.TabIndex = 2;
            // 
            // numericProfit
            // 
            this.numericProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericProfit.DecimalPlaces = 2;
            this.numericProfit.Enabled = false;
            this.numericProfit.Location = new System.Drawing.Point(177, 159);
            this.numericProfit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericProfit.Name = "numericProfit";
            this.numericProfit.Size = new System.Drawing.Size(120, 22);
            this.numericProfit.TabIndex = 6;
            this.numericProfit.ValueChanged += new System.EventHandler(this.NumericProfitValueChanged);
            // 
            // numericProfitPercent
            // 
            this.numericProfitPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericProfitPercent.DecimalPlaces = 1;
            this.numericProfitPercent.Enabled = false;
            this.numericProfitPercent.Location = new System.Drawing.Point(177, 134);
            this.numericProfitPercent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericProfitPercent.Name = "numericProfitPercent";
            this.numericProfitPercent.Size = new System.Drawing.Size(120, 22);
            this.numericProfitPercent.TabIndex = 8;
            this.numericProfitPercent.ValueChanged += new System.EventHandler(this.NumericProfitPercentValueChanged);
            // 
            // numericPrice
            // 
            this.numericPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericPrice.DecimalPlaces = 2;
            this.numericPrice.Enabled = false;
            this.numericPrice.Location = new System.Drawing.Point(177, 187);
            this.numericPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(120, 22);
            this.numericPrice.TabIndex = 10;
            this.numericPrice.ValueChanged += new System.EventHandler(this.NumericPriceValueChanged);
            // 
            // comboCalcMethod
            // 
            this.comboCalcMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboCalcMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCalcMethod.DropDownWidth = 210;
            this.comboCalcMethod.Items.AddRange(new object[] {
            "Расчет суммы прибыли",
            "Расчет процента прибыли"});
            this.comboCalcMethod.Location = new System.Drawing.Point(177, 82);
            this.comboCalcMethod.Name = "comboCalcMethod";
            this.comboCalcMethod.Size = new System.Drawing.Size(176, 21);
            this.comboCalcMethod.TabIndex = 11;
            this.comboCalcMethod.SelectedIndexChanged += new System.EventHandler(this.ComboCalcMethodSelectedIndexChanged);
            // 
            // checkProfit
            // 
            this.checkProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkProfit.Enabled = false;
            this.checkProfit.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkProfit.Location = new System.Drawing.Point(152, 162);
            this.checkProfit.Name = "checkProfit";
            this.checkProfit.Size = new System.Drawing.Size(19, 13);
            this.checkProfit.TabIndex = 5;
            this.checkProfit.Values.Text = "";
            // 
            // checkProfitPercent
            // 
            this.checkProfitPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkProfitPercent.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkProfitPercent.Location = new System.Drawing.Point(152, 137);
            this.checkProfitPercent.Name = "checkProfitPercent";
            this.checkProfitPercent.Size = new System.Drawing.Size(19, 13);
            this.checkProfitPercent.TabIndex = 7;
            this.checkProfitPercent.Values.Text = "";
            // 
            // checkPrice
            // 
            this.checkPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkPrice.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkPrice.Location = new System.Drawing.Point(152, 190);
            this.checkPrice.Name = "checkPrice";
            this.checkPrice.Size = new System.Drawing.Size(19, 13);
            this.checkPrice.TabIndex = 9;
            this.checkPrice.Values.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.pageCommon);
            this.tabControl1.Controls.Add(this.pageCalculation);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 316);
            this.tabControl1.TabIndex = 0;
            // 
            // pageCommon
            // 
            this.pageCommon.Controls.Add(this.checkTaxValue);
            this.pageCommon.Controls.Add(this.comboTaxValue);
            this.pageCommon.Controls.Add(this.textSumma);
            this.pageCommon.Controls.Add(this.textTaxSumma);
            this.pageCommon.Controls.Add(this.kryptonLabel12);
            this.pageCommon.Controls.Add(this.kryptonLabel11);
            this.pageCommon.Controls.Add(this.kryptonLabel10);
            this.pageCommon.Controls.Add(this.textCost);
            this.pageCommon.Controls.Add(this.kryptonLabel1);
            this.pageCommon.Controls.Add(this.kryptonLabel8);
            this.pageCommon.Controls.Add(this.kryptonLabel2);
            this.pageCommon.Controls.Add(this.checkPrice);
            this.pageCommon.Controls.Add(this.kryptonLabel3);
            this.pageCommon.Controls.Add(this.checkProfitPercent);
            this.pageCommon.Controls.Add(this.dateSpec);
            this.pageCommon.Controls.Add(this.checkProfit);
            this.pageCommon.Controls.Add(this.textName);
            this.pageCommon.Controls.Add(this.textComment);
            this.pageCommon.Controls.Add(this.comboCalcMethod);
            this.pageCommon.Controls.Add(this.numericPrice);
            this.pageCommon.Controls.Add(this.kryptonLabel4);
            this.pageCommon.Controls.Add(this.numericProfitPercent);
            this.pageCommon.Controls.Add(this.kryptonLabel5);
            this.pageCommon.Controls.Add(this.numericProfit);
            this.pageCommon.Controls.Add(this.kryptonLabel6);
            this.pageCommon.Controls.Add(this.kryptonLabel7);
            this.pageCommon.Location = new System.Drawing.Point(4, 22);
            this.pageCommon.Name = "pageCommon";
            this.pageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.pageCommon.Size = new System.Drawing.Size(534, 290);
            this.pageCommon.TabIndex = 0;
            this.pageCommon.Text = "Общее";
            this.pageCommon.UseVisualStyleBackColor = true;
            // 
            // checkTaxValue
            // 
            this.checkTaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkTaxValue.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkTaxValue.Location = new System.Drawing.Point(152, 215);
            this.checkTaxValue.Name = "checkTaxValue";
            this.checkTaxValue.Size = new System.Drawing.Size(19, 13);
            this.checkTaxValue.TabIndex = 120;
            this.checkTaxValue.Values.Text = "";
            // 
            // comboTaxValue
            // 
            this.comboTaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboTaxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTaxValue.DropDownWidth = 121;
            this.comboTaxValue.Enabled = false;
            this.comboTaxValue.Items.AddRange(new object[] {
            "Без НДС",
            "10%",
            "18%"});
            this.comboTaxValue.Location = new System.Drawing.Point(177, 212);
            this.comboTaxValue.Name = "comboTaxValue";
            this.comboTaxValue.Size = new System.Drawing.Size(121, 21);
            this.comboTaxValue.TabIndex = 119;
            this.comboTaxValue.SelectedIndexChanged += new System.EventHandler(this.ComboTaxValueSelectedIndexChanged);
            // 
            // textSumma
            // 
            this.textSumma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textSumma.Enabled = false;
            this.textSumma.Location = new System.Drawing.Point(177, 264);
            this.textSumma.Name = "textSumma";
            this.textSumma.Size = new System.Drawing.Size(120, 20);
            this.textSumma.TabIndex = 118;
            // 
            // textTaxSumma
            // 
            this.textTaxSumma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textTaxSumma.Enabled = false;
            this.textTaxSumma.Location = new System.Drawing.Point(177, 238);
            this.textTaxSumma.Name = "textTaxSumma";
            this.textTaxSumma.Size = new System.Drawing.Size(120, 20);
            this.textTaxSumma.TabIndex = 117;
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel12.Location = new System.Drawing.Point(6, 260);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel12.TabIndex = 115;
            this.kryptonLabel12.Values.Text = "Сумма с НДС";
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel11.Location = new System.Drawing.Point(6, 234);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel11.TabIndex = 114;
            this.kryptonLabel11.Values.Text = "Сумма НДС";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel10.Location = new System.Drawing.Point(6, 208);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel10.TabIndex = 113;
            this.kryptonLabel10.Values.Text = "НДС";
            // 
            // textCost
            // 
            this.textCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textCost.Enabled = false;
            this.textCost.Location = new System.Drawing.Point(177, 108);
            this.textCost.Name = "textCost";
            this.textCost.Size = new System.Drawing.Size(120, 20);
            this.textCost.TabIndex = 110;
            // 
            // pageCalculation
            // 
            this.pageCalculation.Controls.Add(this.gridCalc);
            this.pageCalculation.Location = new System.Drawing.Point(4, 22);
            this.pageCalculation.Name = "pageCalculation";
            this.pageCalculation.Padding = new System.Windows.Forms.Padding(6);
            this.pageCalculation.Size = new System.Drawing.Size(534, 290);
            this.pageCalculation.TabIndex = 2;
            this.pageCalculation.Text = "Калькуляция";
            this.pageCalculation.UseVisualStyleBackColor = true;
            // 
            // gridCalc
            // 
            this.gridCalc.AllowUserToAddRows = false;
            this.gridCalc.AllowUserToDeleteRows = false;
            this.gridCalc.AllowUserToResizeRows = false;
            this.gridCalc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCalc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCode,
            this.ColumnName,
            this.ColumnSumma});
            this.gridCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCalc.Location = new System.Drawing.Point(6, 6);
            this.gridCalc.MultiSelect = false;
            this.gridCalc.Name = "gridCalc";
            this.gridCalc.ReadOnly = true;
            this.gridCalc.RowHeadersVisible = false;
            this.gridCalc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCalc.Size = new System.Drawing.Size(522, 278);
            this.gridCalc.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
            this.gridCalc.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.gridCalc.TabIndex = 0;
            // 
            // checkDefault
            // 
            this.checkDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkDefault.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkDefault.Location = new System.Drawing.Point(12, 334);
            this.checkDefault.Name = "checkDefault";
            this.checkDefault.Size = new System.Drawing.Size(109, 20);
            this.checkDefault.TabIndex = 1;
            this.checkDefault.Text = "По умолчанию";
            this.checkDefault.Values.Text = "По умолчанию";
            // 
            // ColumnCode
            // 
            this.ColumnCode.HeaderText = "Код";
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.ReadOnly = true;
            this.ColumnCode.Width = 100;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Наименование";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 321;
            // 
            // ColumnSumma
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSumma.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSumma.HeaderText = "Сумма";
            this.ColumnSumma.Name = "ColumnSumma";
            this.ColumnSumma.ReadOnly = true;
            this.ColumnSumma.Width = 100;
            // 
            // SpecificationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 408);
            this.Controls.Add(this.checkDefault);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(590, 446);
            this.Name = "SpecificationEditor";
            this.Text = "SpecificationEditor";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.checkDefault, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboCalcMethod)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.pageCommon.ResumeLayout(false);
            this.pageCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboTaxValue)).EndInit();
            this.pageCalculation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCalc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TabPage pageCalculation;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkTaxValue;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboTaxValue;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textTaxSumma;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textSumma;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textCost;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkDefault;
        private System.Windows.Forms.TabPage pageCommon;
        private System.Windows.Forms.TabControl tabControl1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkProfitPercent;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkProfit;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboCalcMethod;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numericPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numericProfitPercent;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numericProfit;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textComment;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dateSpec;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCalc;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnSumma;
    }
}
