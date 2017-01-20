//-----------------------------------------------------------------------
// <copyright file="PersonEditor.Design.cs" company="Sergey Teplyashin">
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
// <date>08.11.2014</date>
// <time>17:06</time>
// <summary>Defines the PersonEditor class.</summary>
//-----------------------------------------------------------------------
namespace WorkProject.Editors
{
    partial class PersonEditor
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textSurname;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textFirstName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textMiddleName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textPhone;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        
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
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textSurname = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textFirstName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textMiddleName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textPhone = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.selectGroup = new WorkProject.Controls.SelectBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(123, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Отображаемое имя";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(141, 12);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(231, 20);
            this.textName.TabIndex = 1;
            this.textName.TabStop = false;
            this.textName.TextChanged += new System.EventHandler(this.TextViewNameTextChanged);
            // 
            // textSurname
            // 
            this.textSurname.Location = new System.Drawing.Point(141, 38);
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new System.Drawing.Size(182, 20);
            this.textSurname.TabIndex = 3;
            this.textSurname.TextChanged += new System.EventHandler(this.NameChanged);
            // 
            // textFirstName
            // 
            this.textFirstName.Location = new System.Drawing.Point(141, 64);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(100, 20);
            this.textFirstName.TabIndex = 5;
            this.textFirstName.TextChanged += new System.EventHandler(this.NameChanged);
            // 
            // textMiddleName
            // 
            this.textMiddleName.Location = new System.Drawing.Point(141, 90);
            this.textMiddleName.Name = "textMiddleName";
            this.textMiddleName.Size = new System.Drawing.Size(143, 20);
            this.textMiddleName.TabIndex = 7;
            this.textMiddleName.TextChanged += new System.EventHandler(this.NameChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 38);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Фамилия";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(14, 64);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(35, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Имя";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(14, 90);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Отчество";
            // 
            // textPhone
            // 
            this.textPhone.Location = new System.Drawing.Point(141, 116);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(130, 20);
            this.textPhone.TabIndex = 9;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(14, 116);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Телефон";
            // 
            // selectGroup
            // 
            this.selectGroup.Location = new System.Drawing.Point(141, 168);
            this.selectGroup.Name = "selectGroup";
            this.selectGroup.Size = new System.Drawing.Size(182, 21);
            this.selectGroup.TabIndex = 13;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(12, 168);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(99, 20);
            this.kryptonLabel6.TabIndex = 12;
            this.kryptonLabel6.Values.Text = "Подразделение";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(12, 142);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel7.TabIndex = 10;
            this.kryptonLabel7.Values.Text = "Эл. почта";
            // 
            // textEmail
            // 
            this.textEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEmail.Location = new System.Drawing.Point(141, 142);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(231, 20);
            this.textEmail.TabIndex = 11;
            // 
            // PersonEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 242);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.selectGroup);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.textMiddleName);
            this.Controls.Add(this.textFirstName);
            this.Controls.Add(this.textSurname);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.kryptonLabel1);
            this.MinimumSize = new System.Drawing.Size(400, 280);
            this.Name = "PersonEditor";
            this.Text = "PersonEditor";
            this.Controls.SetChildIndex(this.kryptonLabel1, 0);
            this.Controls.SetChildIndex(this.textName, 0);
            this.Controls.SetChildIndex(this.textSurname, 0);
            this.Controls.SetChildIndex(this.textFirstName, 0);
            this.Controls.SetChildIndex(this.textMiddleName, 0);
            this.Controls.SetChildIndex(this.kryptonLabel2, 0);
            this.Controls.SetChildIndex(this.kryptonLabel3, 0);
            this.Controls.SetChildIndex(this.kryptonLabel4, 0);
            this.Controls.SetChildIndex(this.textPhone, 0);
            this.Controls.SetChildIndex(this.kryptonLabel5, 0);
            this.Controls.SetChildIndex(this.kryptonLabel6, 0);
            this.Controls.SetChildIndex(this.selectGroup, 0);
            this.Controls.SetChildIndex(this.kryptonLabel7, 0);
            this.Controls.SetChildIndex(this.textEmail, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private WorkProject.Controls.SelectBox selectGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textEmail;
    }
}
