//-----------------------------------------------------------------------
// <copyright file=SpecificationListDialog.cs company="NIIAR">
//     Copyright (c) 2016 АО ГНЦ "НИИАР". All rights reserved.
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
    partial class SpecificationListDialog
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridSpecifications;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NameColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOk;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DateColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn DefaultColumn;
        
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
            this.gridSpecifications = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.DateColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NameColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.DefaultColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.buttonOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpecifications)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSpecifications
            // 
            this.gridSpecifications.AllowUserToAddRows = false;
            this.gridSpecifications.AllowUserToDeleteRows = false;
            this.gridSpecifications.AllowUserToResizeColumns = false;
            this.gridSpecifications.AllowUserToResizeRows = false;
            this.gridSpecifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSpecifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSpecifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn,
            this.NameColumn,
            this.DefaultColumn});
            this.gridSpecifications.Location = new System.Drawing.Point(12, 12);
            this.gridSpecifications.MultiSelect = false;
            this.gridSpecifications.Name = "gridSpecifications";
            this.gridSpecifications.RowHeadersVisible = false;
            this.gridSpecifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSpecifications.Size = new System.Drawing.Size(691, 294);
            this.gridSpecifications.TabIndex = 0;
            this.gridSpecifications.SelectionChanged += new System.EventHandler(this.GridSpecificationsSelectionChanged);
            this.gridSpecifications.DoubleClick += new System.EventHandler(this.GridSpecificationsDoubleClick);
            // 
            // DateColumn
            // 
            this.DateColumn.HeaderText = "Дата создания";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            this.DateColumn.Width = 120;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameColumn.HeaderText = "Наименование";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 470;
            // 
            // DefaultColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.DefaultColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DefaultColumn.FalseValue = null;
            this.DefaultColumn.HeaderText = "По умолчанию";
            this.DefaultColumn.IndeterminateValue = null;
            this.DefaultColumn.Name = "DefaultColumn";
            this.DefaultColumn.ReadOnly = true;
            this.DefaultColumn.TrueValue = null;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(517, 312);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(90, 25);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Values.Text = "Выбрать";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(613, 312);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Values.Text = "Отмена";
            // 
            // SpecificationListDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(715, 349);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.gridSpecifications);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpecificationListDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список спецификаций";
            ((System.ComponentModel.ISupportInitialize)(this.gridSpecifications)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
