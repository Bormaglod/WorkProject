//-----------------------------------------------------------------------
// <copyright file="GroupItemEditor.Design.cs" company="Sergey Teplyashin">
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
// <time>9:50</time>
// <summary>Defines the GroupItemEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    partial class GroupItemEditor
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
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.comboParent = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonClear = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.comboParent)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(89, 16);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Наименование";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 38);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(72, 16);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Род. группа";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                    | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(107, 12);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(418, 20);
            this.textName.TabIndex = 1;
            // 
            // comboParent
            // 
            this.comboParent.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
                                    this.buttonClear});
            this.comboParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboParent.DropDownWidth = 216;
            this.comboParent.Location = new System.Drawing.Point(107, 38);
            this.comboParent.Name = "comboParent";
            this.comboParent.Size = new System.Drawing.Size(216, 20);
            this.comboParent.TabIndex = 3;
            // 
            // buttonClear
            // 
            this.buttonClear.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonClear.Image = global::WorkProject.Resources.crest;
            this.buttonClear.UniqueName = "7574F4FC00A8424DD3AF06FEEF81926B";
            this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // GroupItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 114);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.comboParent);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.kryptonLabel2);
            this.MinimumSize = new System.Drawing.Size(545, 148);
            this.Name = "GroupItemEditor";
            this.Text = "GroupItemEditor";
            this.Controls.SetChildIndex(this.kryptonLabel2, 0);
            this.Controls.SetChildIndex(this.kryptonLabel1, 0);
            this.Controls.SetChildIndex(this.comboParent, 0);
            this.Controls.SetChildIndex(this.textName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonClear;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboParent;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
