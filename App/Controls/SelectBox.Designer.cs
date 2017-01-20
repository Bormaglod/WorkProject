//-----------------------------------------------------------------------
// <copyright file="SelectBox.Designer.cs" company="Sergey Teplyashin">
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
// <date>05.11.2014</date>
// <time>13:38</time>
// <summary>Defines the SelectBox class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    partial class SelectBox
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
            this.comboSelect = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonComboClear = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.comboSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // comboSelect
            // 
            this.comboSelect.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonComboClear});
            this.comboSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelect.DropDownWidth = 230;
            this.comboSelect.Location = new System.Drawing.Point(0, 0);
            this.comboSelect.Name = "comboSelect";
            this.comboSelect.Size = new System.Drawing.Size(236, 21);
            this.comboSelect.TabIndex = 1;
            // 
            // buttonComboClear
            // 
            this.buttonComboClear.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonComboClear.Image = global::WorkProject.Resources.crest;
            this.buttonComboClear.UniqueName = "EE9CF99032AF4D4CD7AADA9D70D880B4";
            this.buttonComboClear.Click += new System.EventHandler(this.ButtonComboClearClick);
            // 
            // SelectBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboSelect);
            this.Name = "SelectBox";
            this.Size = new System.Drawing.Size(236, 55);
            ((System.ComponentModel.ISupportInitialize)(this.comboSelect)).EndInit();
            this.ResumeLayout(false);

        }
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonComboClear;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboSelect;
    }
}
