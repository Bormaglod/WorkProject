﻿//-----------------------------------------------------------------------
// <copyright file="MeasurementEditor.Design.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2015 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergey-teplyashin@yandex.ru</email>
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
// <time>19:55</time>
// <summary>Defines the MeasurementEditor class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Editors
{
    partial class MeasurementEditor
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkDefault;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textCode;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textAbbr;
        
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
            this.checkDefault = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.textCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textAbbr = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(32, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Код";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 38);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Наименование";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 64);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(129, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Сокр. наименование";
            // 
            // checkDefault
            // 
            this.checkDefault.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkDefault.Location = new System.Drawing.Point(12, 90);
            this.checkDefault.Name = "checkDefault";
            this.checkDefault.Size = new System.Drawing.Size(188, 20);
            this.checkDefault.TabIndex = 6;
            this.checkDefault.Text = "Используется по умолчанию";
            this.checkDefault.Values.Text = "Используется по умолчанию";
            // 
            // textCode
            // 
            this.textCode.Location = new System.Drawing.Point(147, 12);
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(79, 20);
            this.textCode.TabIndex = 1;
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(147, 38);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(277, 20);
            this.textName.TabIndex = 3;
            // 
            // textAbbr
            // 
            this.textAbbr.Location = new System.Drawing.Point(147, 64);
            this.textAbbr.Name = "textAbbr";
            this.textAbbr.Size = new System.Drawing.Size(208, 20);
            this.textAbbr.TabIndex = 5;
            // 
            // MeasurementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 162);
            this.Controls.Add(this.textAbbr);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textCode);
            this.Controls.Add(this.checkDefault);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.MinimumSize = new System.Drawing.Size(460, 200);
            this.Name = "MeasurementEditor";
            this.Text = "MeasurementEditor";
            this.Controls.SetChildIndex(this.kryptonLabel1, 0);
            this.Controls.SetChildIndex(this.kryptonLabel2, 0);
            this.Controls.SetChildIndex(this.kryptonLabel3, 0);
            this.Controls.SetChildIndex(this.checkDefault, 0);
            this.Controls.SetChildIndex(this.textCode, 0);
            this.Controls.SetChildIndex(this.textName, 0);
            this.Controls.SetChildIndex(this.textAbbr, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
