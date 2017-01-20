//-----------------------------------------------------------------------
// <copyright file="OperationEditor.Design.cs" company="Sergey Teplyashin">
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
// <date>07.11.2014</date>
// <time>9:37</time>
// <summary>Defines the OperationEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    partial class OperationEditor
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.selectGroup = new WorkProject.Controls.SelectBox();
            this.checkSalary = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.numericSalary = new ComponentLib.Controls.TextBoxNumber();
            this.numericTimeRate = new ComponentLib.Controls.TextBoxNumber();
            this.numericPrice = new ComponentLib.Controls.TextBoxNumber();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkTimeRate = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.checkPrice = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Наименование";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 29);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Группа";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 56);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Зар. плата";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 84);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel4.TabIndex = 7;
            this.kryptonLabel4.Values.Text = "Норма времени";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(3, 112);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel5.TabIndex = 10;
            this.kryptonLabel5.Values.Text = "Расценка";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(136, 3);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(261, 20);
            this.textName.TabIndex = 1;
            // 
            // selectGroup
            // 
            this.selectGroup.Location = new System.Drawing.Point(136, 29);
            this.selectGroup.Name = "selectGroup";
            this.selectGroup.Size = new System.Drawing.Size(261, 21);
            this.selectGroup.TabIndex = 3;
            // 
            // checkSalary
            // 
            this.checkSalary.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkSalary.Location = new System.Drawing.Point(111, 56);
            this.checkSalary.Name = "checkSalary";
            this.checkSalary.Size = new System.Drawing.Size(19, 13);
            this.checkSalary.TabIndex = 14;
            this.checkSalary.Tag = "0";
            this.checkSalary.Values.Text = "";
            this.checkSalary.CheckedChanged += new System.EventHandler(this.SelectCalcValue);
            // 
            // numericSalary
            // 
            this.numericSalary.DecimalPlaces = 2;
            this.numericSalary.Location = new System.Drawing.Point(136, 56);
            this.numericSalary.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericSalary.Name = "numericSalary";
            this.numericSalary.Prefix = "";
            this.numericSalary.Size = new System.Drawing.Size(198, 22);
            this.numericSalary.Suffix = "руб./час";
            this.numericSalary.TabIndex = 15;
            this.numericSalary.ValueChanged += new System.EventHandler<System.EventArgs>(this.OperationValuesChanged);
            // 
            // numericTimeRate
            // 
            this.numericTimeRate.Location = new System.Drawing.Point(136, 84);
            this.numericTimeRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericTimeRate.Name = "numericTimeRate";
            this.numericTimeRate.Prefix = "";
            this.numericTimeRate.Size = new System.Drawing.Size(198, 22);
            this.numericTimeRate.Suffix = "шт./час";
            this.numericTimeRate.TabIndex = 16;
            this.numericTimeRate.ValueChanged += new System.EventHandler<System.EventArgs>(this.OperationValuesChanged);
            // 
            // numericPrice
            // 
            this.numericPrice.DecimalPlaces = 3;
            this.numericPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericPrice.Location = new System.Drawing.Point(136, 112);
            this.numericPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Prefix = "";
            this.numericPrice.Size = new System.Drawing.Size(198, 22);
            this.numericPrice.Suffix = "руб.";
            this.numericPrice.TabIndex = 17;
            this.numericPrice.ValueChanged += new System.EventHandler<System.EventArgs>(this.OperationValuesChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.numericPrice, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericTimeRate, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericSalary, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkSalary, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.selectGroup, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkTimeRate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkPrice, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 137);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // checkTimeRate
            // 
            this.checkTimeRate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkTimeRate.Location = new System.Drawing.Point(111, 84);
            this.checkTimeRate.Name = "checkTimeRate";
            this.checkTimeRate.Size = new System.Drawing.Size(19, 13);
            this.checkTimeRate.TabIndex = 15;
            this.checkTimeRate.Tag = "1";
            this.checkTimeRate.Values.Text = "";
            this.checkTimeRate.CheckedChanged += new System.EventHandler(this.SelectCalcValue);
            // 
            // checkPrice
            // 
            this.checkPrice.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkPrice.Location = new System.Drawing.Point(111, 112);
            this.checkPrice.Name = "checkPrice";
            this.checkPrice.Size = new System.Drawing.Size(19, 13);
            this.checkPrice.TabIndex = 16;
            this.checkPrice.Tag = "2";
            this.checkPrice.Values.Text = "";
            this.checkPrice.CheckedChanged += new System.EventHandler(this.SelectCalcValue);
            // 
            // OperationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 203);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(440, 241);
            this.Name = "OperationEditor";
            this.Text = "OperationEditor";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        private ComponentLib.Controls.TextBoxNumber numericPrice;
        private ComponentLib.Controls.TextBoxNumber numericTimeRate;
        private ComponentLib.Controls.TextBoxNumber numericSalary;
        private WorkProject.Controls.SelectBox selectGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkSalary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkTimeRate;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkPrice;
    }
}
