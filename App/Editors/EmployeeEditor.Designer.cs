//-----------------------------------------------------------------------
// <copyright file="EmployeeEditor.Design.cs" company="Sergey Teplyashin">
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
// <date>10.11.2014</date>
// <time>14:39</time>
// <summary>Defines the EmployeeEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    partial class EmployeeEditor
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
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.selectWorkPlace = new WorkProject.Controls.SelectBox();
            this.selectPerson = new WorkProject.Controls.SelectBox();
            this.selectPost = new WorkProject.Controls.SelectBox();
            this.textPhone = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textFax = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.comboStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Организация";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 39);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Физ. лицо";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 66);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "Должность";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 93);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel5.TabIndex = 6;
            this.kryptonLabel5.Values.Text = "Телефон";
            // 
            // selectWorkPlace
            // 
            this.selectWorkPlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectWorkPlace.Location = new System.Drawing.Point(103, 12);
            this.selectWorkPlace.Name = "selectWorkPlace";
            this.selectWorkPlace.Size = new System.Drawing.Size(297, 21);
            this.selectWorkPlace.TabIndex = 1;
            // 
            // selectPerson
            // 
            this.selectPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectPerson.Location = new System.Drawing.Point(103, 39);
            this.selectPerson.Name = "selectPerson";
            this.selectPerson.Size = new System.Drawing.Size(297, 21);
            this.selectPerson.TabIndex = 3;
            // 
            // selectPost
            // 
            this.selectPost.Location = new System.Drawing.Point(103, 66);
            this.selectPost.Name = "selectPost";
            this.selectPost.Size = new System.Drawing.Size(243, 21);
            this.selectPost.TabIndex = 5;
            // 
            // textPhone
            // 
            this.textPhone.Location = new System.Drawing.Point(103, 93);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(201, 20);
            this.textPhone.TabIndex = 7;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(12, 171);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel6.TabIndex = 12;
            this.kryptonLabel6.Values.Text = "Статус";
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.DropDownWidth = 121;
            this.comboStatus.Items.AddRange(new object[] {
            "Не определен",
            "Директор",
            "Гл. бухгалтер",
            "Служащий",
            "Рабочий"});
            this.comboStatus.Location = new System.Drawing.Point(103, 171);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(121, 21);
            this.comboStatus.TabIndex = 13;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 145);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "Эл. почта";
            // 
            // textEmail
            // 
            this.textEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEmail.Location = new System.Drawing.Point(103, 145);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(297, 20);
            this.textEmail.TabIndex = 11;
            // 
            // textFax
            // 
            this.textFax.Location = new System.Drawing.Point(103, 119);
            this.textFax.Name = "textFax";
            this.textFax.Size = new System.Drawing.Size(201, 20);
            this.textFax.TabIndex = 9;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(12, 119);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel7.TabIndex = 8;
            this.kryptonLabel7.Values.Text = "Факс";
            // 
            // EmployeeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 244);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.textFax);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.selectPost);
            this.Controls.Add(this.selectPerson);
            this.Controls.Add(this.selectWorkPlace);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.MinimumSize = new System.Drawing.Size(420, 250);
            this.Name = "EmployeeEditor";
            this.Text = "EmployeeEditor";
            this.Controls.SetChildIndex(this.kryptonLabel3, 0);
            this.Controls.SetChildIndex(this.kryptonLabel4, 0);
            this.Controls.SetChildIndex(this.kryptonLabel5, 0);
            this.Controls.SetChildIndex(this.selectWorkPlace, 0);
            this.Controls.SetChildIndex(this.selectPerson, 0);
            this.Controls.SetChildIndex(this.selectPost, 0);
            this.Controls.SetChildIndex(this.textPhone, 0);
            this.Controls.SetChildIndex(this.kryptonLabel1, 0);
            this.Controls.SetChildIndex(this.kryptonLabel6, 0);
            this.Controls.SetChildIndex(this.comboStatus, 0);
            this.Controls.SetChildIndex(this.kryptonLabel2, 0);
            this.Controls.SetChildIndex(this.textEmail, 0);
            this.Controls.SetChildIndex(this.textFax, 0);
            this.Controls.SetChildIndex(this.kryptonLabel7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textPhone;
        private WorkProject.Controls.SelectBox selectPost;
        private WorkProject.Controls.SelectBox selectPerson;
        private WorkProject.Controls.SelectBox selectWorkPlace;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textFax;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
    }
}
