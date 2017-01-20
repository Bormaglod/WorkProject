﻿//-----------------------------------------------------------------------
// <copyright file="ItemsSelector.Design.cs" company="Sergey Teplyashin">
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
// <date>05.05.2015</date>
// <time>14:15</time>
// <summary>Defines the ItemsSelector class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Dialogs
{
    partial class SelectItemsDialog<TItem, TValue>
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
        	this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
        	this.treeGroups = new WorkProject.Controls.GroupTreeView();
        	this.listItems = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
        	this.kryptonSplitContainer1.Panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
        	this.kryptonSplitContainer1.Panel2.SuspendLayout();
        	this.kryptonSplitContainer1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.buttonOK);
        	this.panel1.Controls.Add(this.buttonCancel);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.panel1.Location = new System.Drawing.Point(0, 450);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(646, 48);
        	this.panel1.TabIndex = 1;
        	// 
        	// buttonOK
        	// 
        	this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOK.Location = new System.Drawing.Point(400, 11);
        	this.buttonOK.Name = "buttonOK";
        	this.buttonOK.Size = new System.Drawing.Size(138, 25);
        	this.buttonOK.TabIndex = 1;
        	this.buttonOK.Values.Text = "Сохранить и закрыть";
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Location = new System.Drawing.Point(544, 11);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(90, 25);
        	this.buttonCancel.TabIndex = 2;
        	this.buttonCancel.Values.Text = "Отмена";
        	// 
        	// kryptonSplitContainer1
        	// 
        	this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
        	this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
        	// 
        	// kryptonSplitContainer1.Panel1
        	// 
        	this.kryptonSplitContainer1.Panel1.Controls.Add(this.treeGroups);
        	this.kryptonSplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
        	this.kryptonSplitContainer1.Panel1.StateCommon.Color1 = System.Drawing.SystemColors.Control;
        	// 
        	// kryptonSplitContainer1.Panel2
        	// 
        	this.kryptonSplitContainer1.Panel2.Controls.Add(this.listItems);
        	this.kryptonSplitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
        	this.kryptonSplitContainer1.Panel2.StateCommon.Color1 = System.Drawing.SystemColors.Control;
        	this.kryptonSplitContainer1.Size = new System.Drawing.Size(646, 450);
        	this.kryptonSplitContainer1.SplitterDistance = 215;
        	this.kryptonSplitContainer1.TabIndex = 2;
        	// 
        	// treeGroups
        	// 
        	this.treeGroups.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.InputControlStandalone;
        	this.treeGroups.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.InputControlStandalone;
        	this.treeGroups.CountDataContains = false;
        	this.treeGroups.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.treeGroups.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.treeGroups.FullRowSelect = true;
        	this.treeGroups.HideSelection = false;
        	this.treeGroups.ItemHeight = 21;
        	this.treeGroups.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
        	this.treeGroups.Location = new System.Drawing.Point(3, 3);
        	this.treeGroups.Name = "treeGroups";
        	this.treeGroups.Size = new System.Drawing.Size(209, 444);
        	this.treeGroups.TabIndex = 0;
        	this.treeGroups.CountItems += new System.EventHandler<WorkProject.Controls.CountItemsEventArgs>(this.TreeGroupsCountItems);
        	this.treeGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeGroupsAfterSelect);
        	// 
        	// listItems
        	// 
        	this.listItems.CheckOnClick = true;
        	this.listItems.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listItems.Location = new System.Drawing.Point(3, 3);
        	this.listItems.Name = "listItems";
        	this.listItems.Size = new System.Drawing.Size(420, 444);
        	this.listItems.TabIndex = 0;
        	this.listItems.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListItemsItemCheck);
        	// 
        	// SelectItemsDialog
        	// 
        	this.AcceptButton = this.buttonOK;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(646, 498);
        	this.Controls.Add(this.kryptonSplitContainer1);
        	this.Controls.Add(this.panel1);
        	this.Name = "SelectItemsDialog";
        	this.Text = "Выбор ...";
        	this.panel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
        	this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
        	this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
        	this.kryptonSplitContainer1.ResumeLayout(false);
        	this.ResumeLayout(false);

        }
        private WorkProject.Controls.GroupTreeView treeGroups;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox listItems;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private System.Windows.Forms.Panel panel1;
    }
}
