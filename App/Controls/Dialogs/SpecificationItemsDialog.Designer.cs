//-----------------------------------------------------------------------
// <copyright file="SpecificationItemsSelector.Design.cs" company="Sergey Teplyashin">
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
// <date>07.05.2015</date>
// <time>10:49</time>
// <summary>Defines the SpecificationItemsSelector class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Dialogs
{
    partial class SpecificationItemsDialog<TItem, TValue>
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
        	this.gridItems = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
        	this.buttonAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.headerGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
        	((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.headerGroup)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.headerGroup.Panel)).BeginInit();
        	this.headerGroup.Panel.SuspendLayout();
        	this.headerGroup.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// gridItems
        	// 
        	this.gridItems.AllowUserToAddRows = false;
        	this.gridItems.AllowUserToDeleteRows = false;
        	this.gridItems.AllowUserToResizeRows = false;
        	this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.gridItems.Location = new System.Drawing.Point(0, 0);
        	this.gridItems.MultiSelect = false;
        	this.gridItems.Name = "gridItems";
        	this.gridItems.Size = new System.Drawing.Size(577, 350);
        	this.gridItems.TabIndex = 0;
        	this.gridItems.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.GridItemsCellParsing);
        	this.gridItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridItemsCellValueChanged);
        	// 
        	// buttonAdd
        	// 
        	this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonAdd.Location = new System.Drawing.Point(597, 12);
        	this.buttonAdd.Name = "buttonAdd";
        	this.buttonAdd.Size = new System.Drawing.Size(90, 25);
        	this.buttonAdd.TabIndex = 1;
        	this.buttonAdd.Values.Text = "Добавить";
        	this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
        	// 
        	// buttonDelete
        	// 
        	this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonDelete.Location = new System.Drawing.Point(597, 43);
        	this.buttonDelete.Name = "buttonDelete";
        	this.buttonDelete.Size = new System.Drawing.Size(90, 25);
        	this.buttonDelete.TabIndex = 2;
        	this.buttonDelete.Values.Text = "Удалить";
        	this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.buttonOK);
        	this.panel1.Controls.Add(this.buttonCancel);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Location = new System.Drawing.Point(0, 391);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(699, 48);
        	this.panel1.TabIndex = 4;
        	// 
        	// buttonOK
        	// 
        	this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOK.Location = new System.Drawing.Point(454, 11);
        	this.buttonOK.Name = "buttonOK";
        	this.buttonOK.Size = new System.Drawing.Size(137, 25);
        	this.buttonOK.TabIndex = 1;
        	this.buttonOK.Values.Text = "Сохранить и закрыть";
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Location = new System.Drawing.Point(597, 11);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(90, 25);
        	this.buttonCancel.TabIndex = 2;
        	this.buttonCancel.Values.Text = "Отмена";
        	// 
        	// headerGroup
        	// 
        	this.headerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.headerGroup.HeaderVisiblePrimary = false;
        	this.headerGroup.Location = new System.Drawing.Point(12, 12);
        	this.headerGroup.Name = "headerGroup";
        	// 
        	// headerGroup.Panel
        	// 
        	this.headerGroup.Panel.Controls.Add(this.gridItems);
        	this.headerGroup.Size = new System.Drawing.Size(579, 373);
        	this.headerGroup.TabIndex = 8;
        	this.headerGroup.ValuesSecondary.Description = "0.00";
        	this.headerGroup.ValuesSecondary.Heading = "ИТОГО сумма:";
        	// 
        	// SpecificationItemsDialog
        	// 
        	this.AcceptButton = this.buttonOK;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(699, 439);
        	this.Controls.Add(this.headerGroup);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.buttonDelete);
        	this.Controls.Add(this.buttonAdd);
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "SpecificationItemsDialog";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Элементы спецификации";
        	((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
        	this.panel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.headerGroup.Panel)).EndInit();
        	this.headerGroup.Panel.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.headerGroup)).EndInit();
        	this.headerGroup.ResumeLayout(false);
        	this.ResumeLayout(false);

        }
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridItems;
    }
}
