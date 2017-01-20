//-----------------------------------------------------------------------
// <copyright file="EntityViewer.Designer.cs" company="Sergey Teplyashin">
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
// <date>20.05.2015</date>
// <time>12:57</time>
// <summary>Defines the EntityViewer class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Controls
{
    partial class EntityViewer<TContent>
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
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
            this.splitTree = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.groupTree = new WorkProject.Controls.GroupTreeView();
            this.contextMenuGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripGroup = new System.Windows.Forms.ToolStrip();
            this.toolAddGroup = new System.Windows.Forms.ToolStripButton();
            this.toolEditGroup = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.splitDetail = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.gridMaster = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuMaster = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopyMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPrintMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourceMaster = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMaster = new System.Windows.Forms.ToolStrip();
            this.toolAddMaster = new System.Windows.Forms.ToolStripButton();
            this.toolCopyMaster = new System.Windows.Forms.ToolStripButton();
            this.toolEditMaster = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteMaster = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrintMaster = new System.Windows.Forms.ToolStripButton();
            this.toolPrintListMaster = new System.Windows.Forms.ToolStripButton();
            this.separatorSend = new System.Windows.Forms.ToolStripSeparator();
            this.toolSend = new System.Windows.Forms.ToolStripButton();
            this.gridDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopyDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPrintDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDetail = new System.Windows.Forms.ToolStrip();
            this.toolAddDetail = new System.Windows.Forms.ToolStripButton();
            this.toolCopyDetail = new System.Windows.Forms.ToolStripButton();
            this.toolEditDetail = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteDetail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrintDetail = new System.Windows.Forms.ToolStripButton();
            this.toolPrintListDetail = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitTree.Panel1)).BeginInit();
            this.splitTree.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTree.Panel2)).BeginInit();
            this.splitTree.Panel2.SuspendLayout();
            this.splitTree.SuspendLayout();
            this.contextMenuGroup.SuspendLayout();
            this.toolStripGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetail.Panel1)).BeginInit();
            this.splitDetail.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetail.Panel2)).BeginInit();
            this.splitDetail.Panel2.SuspendLayout();
            this.splitDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            this.contextMenuMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).BeginInit();
            this.toolStripMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.contextMenuDetail.SuspendLayout();
            this.toolStripDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitTree
            // 
            this.splitTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTree.Location = new System.Drawing.Point(0, 0);
            this.splitTree.Name = "splitTree";
            // 
            // splitTree.Panel1
            // 
            this.splitTree.Panel1.Controls.Add(this.groupTree);
            this.splitTree.Panel1.Controls.Add(this.toolStripGroup);
            // 
            // splitTree.Panel2
            // 
            this.splitTree.Panel2.Controls.Add(this.splitDetail);
            this.splitTree.Size = new System.Drawing.Size(755, 534);
            this.splitTree.SplitterDistance = 251;
            this.splitTree.TabIndex = 0;
            // 
            // groupTree
            // 
            this.groupTree.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.InputControlStandalone;
            this.groupTree.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.InputControlStandalone;
            this.groupTree.ContextMenuStrip = this.contextMenuGroup;
            this.groupTree.CountDataContains = false;
            this.groupTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTree.FullRowSelect = true;
            this.groupTree.HideSelection = false;
            this.groupTree.ItemHeight = 21;
            this.groupTree.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
            this.groupTree.Location = new System.Drawing.Point(0, 25);
            this.groupTree.Name = "groupTree";
            this.groupTree.SelectedId = 0;
            this.groupTree.SelectedItem = null;
            this.groupTree.Size = new System.Drawing.Size(251, 509);
            this.groupTree.TabIndex = 2;
            this.groupTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.GroupTreeAfterSelect);
            this.groupTree.DoubleClick += new System.EventHandler(this.ToolEditGroupClick);
            // 
            // contextMenuGroup
            // 
            this.contextMenuGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddGroup,
            this.menuEditGroup,
            this.menuDeleteGroup});
            this.contextMenuGroup.Name = "contextMenuStrip1";
            this.contextMenuGroup.Size = new System.Drawing.Size(170, 70);
            // 
            // menuAddGroup
            // 
            this.menuAddGroup.Image = global::WorkProject.Resources.folder_add;
            this.menuAddGroup.Name = "menuAddGroup";
            this.menuAddGroup.Size = new System.Drawing.Size(169, 22);
            this.menuAddGroup.Text = "Добавить группу";
            this.menuAddGroup.Click += new System.EventHandler(this.ToolAddGroupClick);
            // 
            // menuEditGroup
            // 
            this.menuEditGroup.Image = global::WorkProject.Resources.folder_edit;
            this.menuEditGroup.Name = "menuEditGroup";
            this.menuEditGroup.Size = new System.Drawing.Size(169, 22);
            this.menuEditGroup.Text = "Изменить группу";
            this.menuEditGroup.Click += new System.EventHandler(this.ToolEditGroupClick);
            // 
            // menuDeleteGroup
            // 
            this.menuDeleteGroup.Image = global::WorkProject.Resources.folder_delete;
            this.menuDeleteGroup.Name = "menuDeleteGroup";
            this.menuDeleteGroup.Size = new System.Drawing.Size(169, 22);
            this.menuDeleteGroup.Text = "Удалить группу";
            this.menuDeleteGroup.Click += new System.EventHandler(this.ToolDeleteGroupClick);
            // 
            // toolStripGroup
            // 
            this.toolStripGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddGroup,
            this.toolEditGroup,
            this.toolDeleteGroup});
            this.toolStripGroup.Location = new System.Drawing.Point(0, 0);
            this.toolStripGroup.Name = "toolStripGroup";
            this.toolStripGroup.Size = new System.Drawing.Size(251, 25);
            this.toolStripGroup.TabIndex = 1;
            this.toolStripGroup.Text = "Группы";
            // 
            // toolAddGroup
            // 
            this.toolAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddGroup.Image = global::WorkProject.Resources.folder_add;
            this.toolAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddGroup.Name = "toolAddGroup";
            this.toolAddGroup.Size = new System.Drawing.Size(23, 22);
            this.toolAddGroup.Text = "Добавить группу";
            this.toolAddGroup.Click += new System.EventHandler(this.ToolAddGroupClick);
            // 
            // toolEditGroup
            // 
            this.toolEditGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditGroup.Image = global::WorkProject.Resources.folder_edit;
            this.toolEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditGroup.Name = "toolEditGroup";
            this.toolEditGroup.Size = new System.Drawing.Size(23, 22);
            this.toolEditGroup.Text = "Изменить группу";
            this.toolEditGroup.Click += new System.EventHandler(this.ToolEditGroupClick);
            // 
            // toolDeleteGroup
            // 
            this.toolDeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDeleteGroup.Image = global::WorkProject.Resources.folder_delete;
            this.toolDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteGroup.Name = "toolDeleteGroup";
            this.toolDeleteGroup.Size = new System.Drawing.Size(23, 22);
            this.toolDeleteGroup.Text = "Удалить группу";
            this.toolDeleteGroup.Click += new System.EventHandler(this.ToolDeleteGroupClick);
            // 
            // splitDetail
            // 
            this.splitDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDetail.Location = new System.Drawing.Point(0, 0);
            this.splitDetail.Name = "splitDetail";
            this.splitDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDetail.Panel1
            // 
            this.splitDetail.Panel1.Controls.Add(this.gridMaster);
            this.splitDetail.Panel1.Controls.Add(this.toolStripMaster);
            // 
            // splitDetail.Panel2
            // 
            this.splitDetail.Panel2.Controls.Add(this.gridDetail);
            this.splitDetail.Panel2.Controls.Add(this.toolStripDetail);
            this.splitDetail.Size = new System.Drawing.Size(499, 534);
            this.splitDetail.SplitterDistance = 302;
            this.splitDetail.TabIndex = 3;
            // 
            // gridMaster
            // 
            this.gridMaster.AllowUserToAddRows = false;
            this.gridMaster.AllowUserToDeleteRows = false;
            this.gridMaster.AllowUserToResizeRows = false;
            this.gridMaster.AutoGenerateColumns = false;
            this.gridMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridMaster.ContextMenuStrip = this.contextMenuMaster;
            this.gridMaster.DataSource = this.bindingSourceMaster;
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.Location = new System.Drawing.Point(0, 25);
            this.gridMaster.MultiSelect = false;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.ReadOnly = true;
            this.gridMaster.RowHeadersVisible = false;
            this.gridMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMaster.Size = new System.Drawing.Size(499, 277);
            this.gridMaster.TabIndex = 3;
            this.gridMaster.SelectionChanged += new System.EventHandler(this.GridMasterSelectionChanged);
            this.gridMaster.DoubleClick += new System.EventHandler(this.ToolEditMasterClick);
            // 
            // contextMenuMaster
            // 
            this.contextMenuMaster.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddMaster,
            this.menuCopyMaster,
            this.menuEditMaster,
            this.menuDeleteMaster,
            this.toolStripSeparator2,
            this.menuPrintMaster});
            this.contextMenuMaster.Name = "contextMenuStrip1";
            this.contextMenuMaster.Size = new System.Drawing.Size(252, 120);
            // 
            // menuAddMaster
            // 
            this.menuAddMaster.Image = global::WorkProject.Resources.application_form_add;
            this.menuAddMaster.Name = "menuAddMaster";
            this.menuAddMaster.Size = new System.Drawing.Size(251, 22);
            this.menuAddMaster.Text = "Добавить запись";
            this.menuAddMaster.Click += new System.EventHandler(this.ToolAddMasterClick);
            // 
            // menuCopyMaster
            // 
            this.menuCopyMaster.Image = global::WorkProject.Resources.application_form_addcopy;
            this.menuCopyMaster.Name = "menuCopyMaster";
            this.menuCopyMaster.Size = new System.Drawing.Size(251, 22);
            this.menuCopyMaster.Text = "Добавить запись копированием";
            this.menuCopyMaster.Click += new System.EventHandler(this.ToolCopyMasterClick);
            // 
            // menuEditMaster
            // 
            this.menuEditMaster.Image = global::WorkProject.Resources.application_form_edit;
            this.menuEditMaster.Name = "menuEditMaster";
            this.menuEditMaster.Size = new System.Drawing.Size(251, 22);
            this.menuEditMaster.Text = "Изменить запись";
            this.menuEditMaster.Click += new System.EventHandler(this.ToolEditMasterClick);
            // 
            // menuDeleteMaster
            // 
            this.menuDeleteMaster.Image = global::WorkProject.Resources.application_form_delete;
            this.menuDeleteMaster.Name = "menuDeleteMaster";
            this.menuDeleteMaster.Size = new System.Drawing.Size(251, 22);
            this.menuDeleteMaster.Text = "Удалить запись";
            this.menuDeleteMaster.Click += new System.EventHandler(this.ToolDeleteMasterClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(248, 6);
            // 
            // menuPrintMaster
            // 
            this.menuPrintMaster.Image = global::WorkProject.Resources.form_print;
            this.menuPrintMaster.Name = "menuPrintMaster";
            this.menuPrintMaster.Size = new System.Drawing.Size(251, 22);
            this.menuPrintMaster.Text = "Печать...";
            // 
            // toolStripMaster
            // 
            this.toolStripMaster.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddMaster,
            this.toolCopyMaster,
            this.toolEditMaster,
            this.toolDeleteMaster,
            this.toolStripSeparator1,
            this.toolPrintMaster,
            this.toolPrintListMaster,
            this.separatorSend,
            this.toolSend});
            this.toolStripMaster.Location = new System.Drawing.Point(0, 0);
            this.toolStripMaster.Name = "toolStripMaster";
            this.toolStripMaster.Size = new System.Drawing.Size(499, 25);
            this.toolStripMaster.TabIndex = 1;
            this.toolStripMaster.Text = "Зпаиси";
            // 
            // toolAddMaster
            // 
            this.toolAddMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddMaster.Image = global::WorkProject.Resources.application_form_add;
            this.toolAddMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddMaster.Name = "toolAddMaster";
            this.toolAddMaster.Size = new System.Drawing.Size(23, 22);
            this.toolAddMaster.Text = "Добавить запись";
            this.toolAddMaster.Click += new System.EventHandler(this.ToolAddMasterClick);
            // 
            // toolCopyMaster
            // 
            this.toolCopyMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCopyMaster.Image = global::WorkProject.Resources.application_form_addcopy;
            this.toolCopyMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopyMaster.Name = "toolCopyMaster";
            this.toolCopyMaster.Size = new System.Drawing.Size(23, 22);
            this.toolCopyMaster.Text = "Добавить запись копированием";
            this.toolCopyMaster.Click += new System.EventHandler(this.ToolCopyMasterClick);
            // 
            // toolEditMaster
            // 
            this.toolEditMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditMaster.Image = global::WorkProject.Resources.application_form_edit;
            this.toolEditMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditMaster.Name = "toolEditMaster";
            this.toolEditMaster.Size = new System.Drawing.Size(23, 22);
            this.toolEditMaster.Text = "Изменить запись";
            this.toolEditMaster.Click += new System.EventHandler(this.ToolEditMasterClick);
            // 
            // toolDeleteMaster
            // 
            this.toolDeleteMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDeleteMaster.Image = global::WorkProject.Resources.application_form_delete;
            this.toolDeleteMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteMaster.Name = "toolDeleteMaster";
            this.toolDeleteMaster.Size = new System.Drawing.Size(23, 22);
            this.toolDeleteMaster.Text = "Удалить запись";
            this.toolDeleteMaster.Click += new System.EventHandler(this.ToolDeleteMasterClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPrintMaster
            // 
            this.toolPrintMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrintMaster.Image = global::WorkProject.Resources.form_print;
            this.toolPrintMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintMaster.Name = "toolPrintMaster";
            this.toolPrintMaster.Size = new System.Drawing.Size(23, 22);
            this.toolPrintMaster.Text = "Печать...";
            this.toolPrintMaster.Click += new System.EventHandler(this.ToolPrintMasterClick);
            // 
            // toolPrintListMaster
            // 
            this.toolPrintListMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrintListMaster.Image = global::WorkProject.Resources.table_print;
            this.toolPrintListMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintListMaster.Name = "toolPrintListMaster";
            this.toolPrintListMaster.Size = new System.Drawing.Size(23, 22);
            this.toolPrintListMaster.Text = "Печать списка";
            // 
            // separatorSend
            // 
            this.separatorSend.Name = "separatorSend";
            this.separatorSend.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSend
            // 
            this.toolSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSend.Image = global::WorkProject.Resources.email_go;
            this.toolSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSend.Name = "toolSend";
            this.toolSend.Size = new System.Drawing.Size(23, 22);
            this.toolSend.Text = "Отправить...";
            this.toolSend.Click += new System.EventHandler(this.ToolSendClick);
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.AllowUserToResizeRows = false;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDetail.ContextMenuStrip = this.contextMenuDetail;
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 25);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.RowHeadersVisible = false;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetail.Size = new System.Drawing.Size(499, 202);
            this.gridDetail.TabIndex = 3;
            this.gridDetail.DoubleClick += new System.EventHandler(this.ToolEditDetailClick);
            // 
            // contextMenuDetail
            // 
            this.contextMenuDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddDetail,
            this.menuCopyDetail,
            this.menuEditDetail,
            this.menuDeleteDetail,
            this.toolStripSeparator4,
            this.menuPrintDetail});
            this.contextMenuDetail.Name = "contextMenuStrip1";
            this.contextMenuDetail.Size = new System.Drawing.Size(252, 120);
            // 
            // menuAddDetail
            // 
            this.menuAddDetail.Image = global::WorkProject.Resources.application_form_add;
            this.menuAddDetail.Name = "menuAddDetail";
            this.menuAddDetail.Size = new System.Drawing.Size(251, 22);
            this.menuAddDetail.Text = "Добавить запись";
            // 
            // menuCopyDetail
            // 
            this.menuCopyDetail.Image = global::WorkProject.Resources.application_form_addcopy;
            this.menuCopyDetail.Name = "menuCopyDetail";
            this.menuCopyDetail.Size = new System.Drawing.Size(251, 22);
            this.menuCopyDetail.Text = "Добавить запись копированием";
            // 
            // menuEditDetail
            // 
            this.menuEditDetail.Image = global::WorkProject.Resources.application_form_edit;
            this.menuEditDetail.Name = "menuEditDetail";
            this.menuEditDetail.Size = new System.Drawing.Size(251, 22);
            this.menuEditDetail.Text = "Изменить запись";
            // 
            // menuDeleteDetail
            // 
            this.menuDeleteDetail.Image = global::WorkProject.Resources.application_form_delete;
            this.menuDeleteDetail.Name = "menuDeleteDetail";
            this.menuDeleteDetail.Size = new System.Drawing.Size(251, 22);
            this.menuDeleteDetail.Text = "Удалить запись";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(248, 6);
            // 
            // menuPrintDetail
            // 
            this.menuPrintDetail.Image = global::WorkProject.Resources.form_print;
            this.menuPrintDetail.Name = "menuPrintDetail";
            this.menuPrintDetail.Size = new System.Drawing.Size(251, 22);
            this.menuPrintDetail.Text = "Печать...";
            // 
            // toolStripDetail
            // 
            this.toolStripDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddDetail,
            this.toolCopyDetail,
            this.toolEditDetail,
            this.toolDeleteDetail,
            this.toolStripSeparator3,
            this.toolPrintDetail,
            this.toolPrintListDetail});
            this.toolStripDetail.Location = new System.Drawing.Point(0, 0);
            this.toolStripDetail.Name = "toolStripDetail";
            this.toolStripDetail.Size = new System.Drawing.Size(499, 25);
            this.toolStripDetail.TabIndex = 2;
            this.toolStripDetail.Text = "toolStrip1";
            // 
            // toolAddDetail
            // 
            this.toolAddDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddDetail.Image = global::WorkProject.Resources.application_form_add;
            this.toolAddDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddDetail.Name = "toolAddDetail";
            this.toolAddDetail.Size = new System.Drawing.Size(23, 22);
            this.toolAddDetail.Text = "Добавить запись";
            this.toolAddDetail.Click += new System.EventHandler(this.ToolAddDetailClick);
            // 
            // toolCopyDetail
            // 
            this.toolCopyDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCopyDetail.Image = global::WorkProject.Resources.application_form_addcopy;
            this.toolCopyDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopyDetail.Name = "toolCopyDetail";
            this.toolCopyDetail.Size = new System.Drawing.Size(23, 22);
            this.toolCopyDetail.Text = "Добавить запись копированием";
            this.toolCopyDetail.Click += new System.EventHandler(this.ToolCopyDetailClick);
            // 
            // toolEditDetail
            // 
            this.toolEditDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditDetail.Image = global::WorkProject.Resources.application_form_edit;
            this.toolEditDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditDetail.Name = "toolEditDetail";
            this.toolEditDetail.Size = new System.Drawing.Size(23, 22);
            this.toolEditDetail.Text = "Изменить запись";
            this.toolEditDetail.Click += new System.EventHandler(this.ToolEditDetailClick);
            // 
            // toolDeleteDetail
            // 
            this.toolDeleteDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDeleteDetail.Image = global::WorkProject.Resources.application_form_delete;
            this.toolDeleteDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteDetail.Name = "toolDeleteDetail";
            this.toolDeleteDetail.Size = new System.Drawing.Size(23, 22);
            this.toolDeleteDetail.Text = "Удалить запись";
            this.toolDeleteDetail.Click += new System.EventHandler(this.ToolDeleteDetailClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPrintDetail
            // 
            this.toolPrintDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrintDetail.Image = global::WorkProject.Resources.form_print;
            this.toolPrintDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintDetail.Name = "toolPrintDetail";
            this.toolPrintDetail.Size = new System.Drawing.Size(23, 22);
            this.toolPrintDetail.Text = "Печать...";
            this.toolPrintDetail.Click += new System.EventHandler(this.ToolPrintDetailClick);
            // 
            // toolPrintListDetail
            // 
            this.toolPrintListDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrintListDetail.Image = global::WorkProject.Resources.table_print;
            this.toolPrintListDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintListDetail.Name = "toolPrintListDetail";
            this.toolPrintListDetail.Size = new System.Drawing.Size(23, 22);
            this.toolPrintListDetail.Text = "Печать списка";
            // 
            // EntityViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitTree);
            this.Name = "EntityViewer";
            this.Size = new System.Drawing.Size(755, 534);
            ((System.ComponentModel.ISupportInitialize)(this.splitTree.Panel1)).EndInit();
            this.splitTree.Panel1.ResumeLayout(false);
            this.splitTree.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTree.Panel2)).EndInit();
            this.splitTree.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTree)).EndInit();
            this.splitTree.ResumeLayout(false);
            this.contextMenuGroup.ResumeLayout(false);
            this.toolStripGroup.ResumeLayout(false);
            this.toolStripGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetail.Panel1)).EndInit();
            this.splitDetail.Panel1.ResumeLayout(false);
            this.splitDetail.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetail.Panel2)).EndInit();
            this.splitDetail.Panel2.ResumeLayout(false);
            this.splitDetail.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetail)).EndInit();
            this.splitDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            this.contextMenuMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).EndInit();
            this.toolStripMaster.ResumeLayout(false);
            this.toolStripMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.contextMenuDetail.ResumeLayout(false);
            this.toolStripDetail.ResumeLayout(false);
            this.toolStripDetail.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ToolStripMenuItem menuDeleteDetail;
        private System.Windows.Forms.ToolStripMenuItem menuEditDetail;
        private System.Windows.Forms.ToolStripMenuItem menuCopyDetail;
        private System.Windows.Forms.ToolStripMenuItem menuAddDetail;
        private System.Windows.Forms.ContextMenuStrip contextMenuDetail;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDetail;
        private System.Windows.Forms.ToolStripButton toolDeleteDetail;
        private System.Windows.Forms.ToolStripButton toolEditDetail;
        private System.Windows.Forms.ToolStripButton toolCopyDetail;
        private System.Windows.Forms.ToolStripButton toolAddDetail;
        private System.Windows.Forms.ToolStrip toolStripDetail;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitDetail;
        private System.Windows.Forms.BindingSource bindingSourceMaster;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteMaster;
        private System.Windows.Forms.ToolStripMenuItem menuEditMaster;
        private System.Windows.Forms.ToolStripMenuItem menuCopyMaster;
        private System.Windows.Forms.ToolStripMenuItem menuAddMaster;
        private System.Windows.Forms.ContextMenuStrip contextMenuMaster;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridMaster;
        private System.Windows.Forms.ToolStripButton toolDeleteMaster;
        private System.Windows.Forms.ToolStripButton toolEditMaster;
        private System.Windows.Forms.ToolStripButton toolCopyMaster;
        private System.Windows.Forms.ToolStripButton toolAddMaster;
        private System.Windows.Forms.ToolStrip toolStripMaster;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem menuEditGroup;
        private System.Windows.Forms.ToolStripMenuItem menuAddGroup;
        private System.Windows.Forms.ContextMenuStrip contextMenuGroup;
        private WorkProject.Controls.GroupTreeView groupTree;
        private System.Windows.Forms.ToolStripButton toolDeleteGroup;
        private System.Windows.Forms.ToolStripButton toolEditGroup;
        private System.Windows.Forms.ToolStripButton toolAddGroup;
        private System.Windows.Forms.ToolStrip toolStripGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitTree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolPrintMaster;
        private System.Windows.Forms.ToolStripButton toolPrintListMaster;
        private System.Windows.Forms.ToolStripSeparator separatorSend;
        private System.Windows.Forms.ToolStripButton toolSend;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuPrintMaster;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuPrintDetail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolPrintDetail;
        private System.Windows.Forms.ToolStripButton toolPrintListDetail;
    }
}
