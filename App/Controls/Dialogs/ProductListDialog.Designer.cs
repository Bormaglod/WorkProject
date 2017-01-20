//-----------------------------------------------------------------------
// <copyright file="ProductListDialog.cs" company="Sergey Teplyashin">
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
// <date>26.06.2015</date>
// <time>10:24</time>
// <summary>Defines the ProductListDialog class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Dialogs
{
    partial class ProductListDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gridProducts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ProductColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.SpecificationColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.buttonSelectSpec = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.CountColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.checkMinOrder = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.checkSupplier = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 48);
            this.panel1.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(414, 11);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(142, 25);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Values.Text = "Сохранить и закрыть";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(562, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Values.Text = "Отмена";
            // 
            // gridProducts
            // 
            this.gridProducts.AllowUserToAddRows = false;
            this.gridProducts.AllowUserToDeleteRows = false;
            this.gridProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductColumn,
            this.SpecificationColumn,
            this.CountColumn});
            this.gridProducts.Location = new System.Drawing.Point(12, 12);
            this.gridProducts.MultiSelect = false;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.Size = new System.Drawing.Size(640, 232);
            this.gridProducts.TabIndex = 6;
            this.gridProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridProductsCellFormatting);
            // 
            // ProductColumn
            // 
            this.ProductColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductColumn.HeaderText = "Продукт";
            this.ProductColumn.Name = "ProductColumn";
            this.ProductColumn.ReadOnly = true;
            this.ProductColumn.Width = 250;
            // 
            // SpecificationColumn
            // 
            this.SpecificationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SpecificationColumn.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSelectSpec});
            this.SpecificationColumn.HeaderText = "Спецификация";
            this.SpecificationColumn.Name = "SpecificationColumn";
            this.SpecificationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SpecificationColumn.Width = 249;
            // 
            // buttonSelectSpec
            // 
            this.buttonSelectSpec.Image = global::WorkProject.Resources.points;
            this.buttonSelectSpec.UniqueName = "B2AC04D0076F4D7050BCCA2A2133FB39";
            // 
            // CountColumn
            // 
            this.CountColumn.HeaderText = "Количество";
            this.CountColumn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CountColumn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CountColumn.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CountColumn.Name = "CountColumn";
            this.CountColumn.Width = 100;
            // 
            // checkMinOrder
            // 
            this.checkMinOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkMinOrder.Checked = true;
            this.checkMinOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMinOrder.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkMinOrder.Location = new System.Drawing.Point(12, 250);
            this.checkMinOrder.Name = "checkMinOrder";
            this.checkMinOrder.Size = new System.Drawing.Size(306, 20);
            this.checkMinOrder.TabIndex = 7;
            this.checkMinOrder.Text = "Округлять количество материалов до мин. заказа";
            this.checkMinOrder.Values.Text = "Округлять количество материалов до мин. заказа";
            // 
            // checkSupplier
            // 
            this.checkSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSupplier.Checked = true;
            this.checkSupplier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSupplier.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkSupplier.Location = new System.Drawing.Point(12, 272);
            this.checkSupplier.Name = "checkSupplier";
            this.checkSupplier.Size = new System.Drawing.Size(330, 20);
            this.checkSupplier.TabIndex = 8;
            this.checkSupplier.Text = "Добавить материалы только выбранного поставщика";
            this.checkSupplier.Values.Text = "Добавить материалы только выбранного поставщика";
            // 
            // ProductListDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(664, 346);
            this.Controls.Add(this.checkSupplier);
            this.Controls.Add(this.checkMinOrder);
            this.Controls.Add(this.gridProducts);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductListDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список изделий";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkSupplier;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkMinOrder;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn CountColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SpecificationColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ProductColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridProducts;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSelectSpec;
    }
}
