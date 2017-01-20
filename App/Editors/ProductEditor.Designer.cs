//-----------------------------------------------------------------------
// <copyright file="ProductEditor.Design.cs" company="Sergey Teplyashin">
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
// <time>12:58</time>
// <summary>Defines the ProductEditor class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Editors
{
    partial class ProductEditor
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
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textFullName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textArticle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textPrice = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textTaxValue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textTaxSumma = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textSumma = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 81);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Цена";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 107);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel3.TabIndex = 8;
            this.kryptonLabel3.Values.Text = "НДС";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 133);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "Сумма НДС";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(3, 159);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel5.TabIndex = 12;
            this.kryptonLabel5.Values.Text = "Сумма";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(3, 29);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel6.TabIndex = 2;
            this.kryptonLabel6.Values.Text = "Полное наименование";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(3, 55);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel7.TabIndex = 4;
            this.kryptonLabel7.Values.Text = "Артикул";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(150, 3);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(201, 20);
            this.textName.TabIndex = 1;
            // 
            // textFullName
            // 
            this.textFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFullName.Location = new System.Drawing.Point(150, 29);
            this.textFullName.Name = "textFullName";
            this.textFullName.Size = new System.Drawing.Size(293, 20);
            this.textFullName.TabIndex = 3;
            // 
            // textArticle
            // 
            this.textArticle.Location = new System.Drawing.Point(150, 55);
            this.textArticle.Name = "textArticle";
            this.textArticle.Size = new System.Drawing.Size(201, 20);
            this.textArticle.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textFullName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textArticle, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textPrice, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textTaxValue, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textTaxSumma, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textSumma, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 190);
            this.tableLayoutPanel1.TabIndex = 116;
            // 
            // textPrice
            // 
            this.textPrice.Enabled = false;
            this.textPrice.Location = new System.Drawing.Point(150, 81);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(100, 20);
            this.textPrice.TabIndex = 14;
            // 
            // textTaxValue
            // 
            this.textTaxValue.Enabled = false;
            this.textTaxValue.Location = new System.Drawing.Point(150, 107);
            this.textTaxValue.Name = "textTaxValue";
            this.textTaxValue.Size = new System.Drawing.Size(100, 20);
            this.textTaxValue.TabIndex = 15;
            // 
            // textTaxSumma
            // 
            this.textTaxSumma.Enabled = false;
            this.textTaxSumma.Location = new System.Drawing.Point(150, 133);
            this.textTaxSumma.Name = "textTaxSumma";
            this.textTaxSumma.Size = new System.Drawing.Size(100, 20);
            this.textTaxSumma.TabIndex = 16;
            // 
            // textSumma
            // 
            this.textSumma.Enabled = false;
            this.textSumma.Location = new System.Drawing.Point(150, 159);
            this.textSumma.Name = "textSumma";
            this.textSumma.Size = new System.Drawing.Size(100, 20);
            this.textSumma.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(9, 9, 9, 0);
            this.panel2.Size = new System.Drawing.Size(464, 199);
            this.panel2.TabIndex = 117;
            // 
            // ProductEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 247);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(480, 285);
            this.Name = "ProductEditor";
            this.Text = "ProductEditor";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textSumma;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textTaxSumma;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textTaxValue;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textPrice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textArticle;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textFullName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
