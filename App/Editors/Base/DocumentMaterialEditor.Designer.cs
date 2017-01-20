//-----------------------------------------------------------------------
// <copyright file="DocumentMaterialEditor.Design.cs" company="Sergey Teplyashin">
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
// <date>18.05.2015</date>
// <time>13:54</time>
// <summary>Defines the DocumentMaterialEditor class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Editors.Base
{
    #if DEVELOP
    partial class DocumentMaterialEditor
    #else
    partial class DocumentMaterialEditor<TDocument, TItem>
    #endif
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
            this.dateDoc = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panelCommon = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.selectOrganization = new WorkProject.Controls.SelectBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panelContractor = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.selectContractor = new WorkProject.Controls.SelectBox();
            this.panelMaterials = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.headerGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridMaterials = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolRemove = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelCommon)).BeginInit();
            this.panelCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContractor)).BeginInit();
            this.panelContractor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMaterials)).BeginInit();
            this.panelMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup.Panel)).BeginInit();
            this.headerGroup.Panel.SuspendLayout();
            this.headerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterials)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Номер";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 37);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(77, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Дата/время";
            // 
            // dateDoc
            // 
            this.dateDoc.Location = new System.Drawing.Point(103, 38);
            this.dateDoc.Name = "dateDoc";
            this.dateDoc.Size = new System.Drawing.Size(162, 21);
            this.dateDoc.TabIndex = 4;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 6);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Контрагент";
            // 
            // panelCommon
            // 
            this.panelCommon.Controls.Add(this.selectOrganization);
            this.panelCommon.Controls.Add(this.kryptonLabel4);
            this.panelCommon.Controls.Add(this.textNumber);
            this.panelCommon.Controls.Add(this.kryptonLabel1);
            this.panelCommon.Controls.Add(this.kryptonLabel2);
            this.panelCommon.Controls.Add(this.dateDoc);
            this.panelCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommon.Location = new System.Drawing.Point(0, 0);
            this.panelCommon.Name = "panelCommon";
            this.panelCommon.Size = new System.Drawing.Size(624, 94);
            this.panelCommon.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.panelCommon.TabIndex = 7;
            // 
            // selectOrganization
            // 
            this.selectOrganization.Location = new System.Drawing.Point(103, 64);
            this.selectOrganization.Name = "selectOrganization";
            this.selectOrganization.Size = new System.Drawing.Size(236, 21);
            this.selectOrganization.TabIndex = 7;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 64);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Организация";
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(103, 12);
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(100, 20);
            this.textNumber.TabIndex = 5;
            // 
            // panelContractor
            // 
            this.panelContractor.Controls.Add(this.selectContractor);
            this.panelContractor.Controls.Add(this.kryptonLabel3);
            this.panelContractor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContractor.Location = new System.Drawing.Point(0, 94);
            this.panelContractor.Name = "panelContractor";
            this.panelContractor.Size = new System.Drawing.Size(624, 40);
            this.panelContractor.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.panelContractor.TabIndex = 8;
            // 
            // selectContractor
            // 
            this.selectContractor.Location = new System.Drawing.Point(103, 6);
            this.selectContractor.Name = "selectContractor";
            this.selectContractor.Size = new System.Drawing.Size(236, 21);
            this.selectContractor.TabIndex = 6;
            // 
            // panelMaterials
            // 
            this.panelMaterials.Controls.Add(this.headerGroup);
            this.panelMaterials.Controls.Add(this.toolStrip1);
            this.panelMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaterials.Location = new System.Drawing.Point(0, 134);
            this.panelMaterials.Name = "panelMaterials";
            this.panelMaterials.Padding = new System.Windows.Forms.Padding(6);
            this.panelMaterials.Size = new System.Drawing.Size(624, 340);
            this.panelMaterials.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.panelMaterials.TabIndex = 9;
            // 
            // headerGroup
            // 
            this.headerGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroup.HeaderVisiblePrimary = false;
            this.headerGroup.Location = new System.Drawing.Point(6, 31);
            this.headerGroup.Name = "headerGroup";
            // 
            // headerGroup.Panel
            // 
            this.headerGroup.Panel.Controls.Add(this.gridMaterials);
            this.headerGroup.Size = new System.Drawing.Size(612, 303);
            this.headerGroup.TabIndex = 2;
            this.headerGroup.ValuesSecondary.Description = "0.00";
            this.headerGroup.ValuesSecondary.Heading = "ИТОГО сумма:";
            // 
            // gridMaterials
            // 
            this.gridMaterials.AllowUserToAddRows = false;
            this.gridMaterials.AllowUserToDeleteRows = false;
            this.gridMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaterials.Location = new System.Drawing.Point(0, 0);
            this.gridMaterials.MultiSelect = false;
            this.gridMaterials.Name = "gridMaterials";
            this.gridMaterials.Size = new System.Drawing.Size(610, 280);
            this.gridMaterials.TabIndex = 1;
            this.gridMaterials.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridMaterialsCellValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolRemove});
            this.toolStrip1.Location = new System.Drawing.Point(6, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(612, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAdd.Image = global::WorkProject.Resources.application_form_add;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(23, 22);
            this.toolAdd.Text = "Добавить материал";
            this.toolAdd.Click += new System.EventHandler(this.ToolAddClick);
            // 
            // toolRemove
            // 
            this.toolRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRemove.Image = global::WorkProject.Resources.application_form_delete;
            this.toolRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRemove.Name = "toolRemove";
            this.toolRemove.Size = new System.Drawing.Size(23, 22);
            this.toolRemove.Text = "Удалить материал";
            this.toolRemove.Click += new System.EventHandler(this.ToolRemoveClick);
            // 
            // DocumentMaterialEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 522);
            this.Controls.Add(this.panelMaterials);
            this.Controls.Add(this.panelContractor);
            this.Controls.Add(this.panelCommon);
            this.MinimumSize = new System.Drawing.Size(640, 360);
            this.Name = "DocumentMaterialEditor";
            this.Text = "DocumentMaterialEditor";
            this.Controls.SetChildIndex(this.panelCommon, 0);
            this.Controls.SetChildIndex(this.panelContractor, 0);
            this.Controls.SetChildIndex(this.panelMaterials, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelCommon)).EndInit();
            this.panelCommon.ResumeLayout(false);
            this.panelCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContractor)).EndInit();
            this.panelContractor.ResumeLayout(false);
            this.panelContractor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMaterials)).EndInit();
            this.panelMaterials.ResumeLayout(false);
            this.panelMaterials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup.Panel)).EndInit();
            this.headerGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroup)).EndInit();
            this.headerGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterials)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroup;
        private WorkProject.Controls.SelectBox selectContractor;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textNumber;
        private System.Windows.Forms.ToolStripButton toolRemove;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridMaterials;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelMaterials;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelContractor;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelCommon;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dateDoc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private WorkProject.Controls.SelectBox selectOrganization;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
    }
}
