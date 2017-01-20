//-----------------------------------------------------------------------
// <copyright file="MaterialEditor.Design.cs" company="Sergey Teplyashin">
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
// <time>14:55</time>
// <summary>Defines the MaterialEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    partial class MaterialEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialEditor));
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.selectMeasurement = new WorkProject.Controls.SelectBox();
            this.numericPrice = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.comboTax = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.selectGroup = new WorkProject.Controls.SelectBox();
            this.numericBeginRemainder = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.numericMinOrder = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.checkService = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textArticle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textArticleAlt = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.checkDetails = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.buttonDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.listDetails = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.tabSupplier = new System.Windows.Forms.TabPage();
            this.gridSuppliers = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.imageMaterial = new ComponentLib.Controls.ImageBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.comboTax)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.tabSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSuppliers)).BeginInit();
            this.tabImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 6);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Наименование";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 84);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(124, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Единица измерения";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 111);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel3.TabIndex = 8;
            this.kryptonLabel3.Values.Text = "Цена без НДС";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(6, 139);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "НДС";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(6, 166);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(121, 20);
            this.kryptonLabel5.TabIndex = 12;
            this.kryptonLabel5.Values.Text = "Группа материалов";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(6, 193);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(121, 20);
            this.kryptonLabel6.TabIndex = 14;
            this.kryptonLabel6.Values.Text = "Начальный остаток";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(6, 221);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(121, 20);
            this.kryptonLabel7.TabIndex = 16;
            this.kryptonLabel7.Values.Text = "Мин. партия заказа";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(136, 6);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(508, 20);
            this.textName.TabIndex = 1;
            // 
            // selectMeasurement
            // 
            this.selectMeasurement.Location = new System.Drawing.Point(136, 84);
            this.selectMeasurement.Name = "selectMeasurement";
            this.selectMeasurement.Size = new System.Drawing.Size(182, 21);
            this.selectMeasurement.TabIndex = 7;
            // 
            // numericPrice
            // 
            this.numericPrice.DecimalPlaces = 2;
            this.numericPrice.Location = new System.Drawing.Point(136, 111);
            this.numericPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(120, 22);
            this.numericPrice.TabIndex = 9;
            // 
            // comboTax
            // 
            this.comboTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTax.DropDownWidth = 121;
            this.comboTax.Items.AddRange(new object[] {
            "Без НДС",
            "10%",
            "18%"});
            this.comboTax.Location = new System.Drawing.Point(136, 139);
            this.comboTax.Name = "comboTax";
            this.comboTax.Size = new System.Drawing.Size(121, 21);
            this.comboTax.TabIndex = 11;
            // 
            // selectGroup
            // 
            this.selectGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectGroup.Location = new System.Drawing.Point(136, 166);
            this.selectGroup.Name = "selectGroup";
            this.selectGroup.Size = new System.Drawing.Size(508, 21);
            this.selectGroup.TabIndex = 13;
            // 
            // numericBeginRemainder
            // 
            this.numericBeginRemainder.DecimalPlaces = 3;
            this.numericBeginRemainder.Location = new System.Drawing.Point(136, 193);
            this.numericBeginRemainder.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericBeginRemainder.Name = "numericBeginRemainder";
            this.numericBeginRemainder.Size = new System.Drawing.Size(120, 22);
            this.numericBeginRemainder.TabIndex = 15;
            // 
            // numericMinOrder
            // 
            this.numericMinOrder.DecimalPlaces = 3;
            this.numericMinOrder.Location = new System.Drawing.Point(136, 221);
            this.numericMinOrder.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericMinOrder.Name = "numericMinOrder";
            this.numericMinOrder.Size = new System.Drawing.Size(120, 22);
            this.numericMinOrder.TabIndex = 17;
            // 
            // checkService
            // 
            this.checkService.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkService.Location = new System.Drawing.Point(6, 275);
            this.checkService.Name = "checkService";
            this.checkService.Size = new System.Drawing.Size(60, 20);
            this.checkService.TabIndex = 18;
            this.checkService.Text = "Услуга";
            this.checkService.Values.Text = "Услуга";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(6, 32);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel8.TabIndex = 2;
            this.kryptonLabel8.Values.Text = "Артикул";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(6, 58);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel9.TabIndex = 4;
            this.kryptonLabel9.Values.Text = "Доп. артикул";
            // 
            // textArticle
            // 
            this.textArticle.Location = new System.Drawing.Point(136, 32);
            this.textArticle.Name = "textArticle";
            this.textArticle.Size = new System.Drawing.Size(182, 20);
            this.textArticle.TabIndex = 3;
            // 
            // textArticleAlt
            // 
            this.textArticleAlt.Location = new System.Drawing.Point(136, 58);
            this.textArticleAlt.Name = "textArticleAlt";
            this.textArticleAlt.Size = new System.Drawing.Size(182, 20);
            this.textArticleAlt.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabCommon);
            this.tabControl1.Controls.Add(this.tabDetail);
            this.tabControl1.Controls.Add(this.tabSupplier);
            this.tabControl1.Controls.Add(this.tabImage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(658, 329);
            this.tabControl1.TabIndex = 19;
            // 
            // tabCommon
            // 
            this.tabCommon.Controls.Add(this.checkDetails);
            this.tabCommon.Controls.Add(this.kryptonLabel1);
            this.tabCommon.Controls.Add(this.textArticleAlt);
            this.tabCommon.Controls.Add(this.kryptonLabel3);
            this.tabCommon.Controls.Add(this.textArticle);
            this.tabCommon.Controls.Add(this.kryptonLabel5);
            this.tabCommon.Controls.Add(this.kryptonLabel9);
            this.tabCommon.Controls.Add(this.kryptonLabel2);
            this.tabCommon.Controls.Add(this.kryptonLabel8);
            this.tabCommon.Controls.Add(this.kryptonLabel6);
            this.tabCommon.Controls.Add(this.kryptonLabel7);
            this.tabCommon.Controls.Add(this.kryptonLabel4);
            this.tabCommon.Controls.Add(this.checkService);
            this.tabCommon.Controls.Add(this.textName);
            this.tabCommon.Controls.Add(this.numericMinOrder);
            this.tabCommon.Controls.Add(this.numericPrice);
            this.tabCommon.Controls.Add(this.numericBeginRemainder);
            this.tabCommon.Controls.Add(this.comboTax);
            this.tabCommon.Controls.Add(this.selectMeasurement);
            this.tabCommon.Controls.Add(this.selectGroup);
            this.tabCommon.Location = new System.Drawing.Point(4, 22);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommon.Size = new System.Drawing.Size(650, 303);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "Общее";
            this.tabCommon.UseVisualStyleBackColor = true;
            // 
            // checkDetails
            // 
            this.checkDetails.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.checkDetails.Location = new System.Drawing.Point(6, 249);
            this.checkDetails.Name = "checkDetails";
            this.checkDetails.Size = new System.Drawing.Size(143, 20);
            this.checkDetails.TabIndex = 19;
            this.checkDetails.Text = "Варанты исполнения";
            this.checkDetails.Values.Text = "Варанты исполнения";
            this.checkDetails.CheckedChanged += new System.EventHandler(this.CheckDetailsCheckedChanged);
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.buttonDelete);
            this.tabDetail.Controls.Add(this.buttonEdit);
            this.tabDetail.Controls.Add(this.buttonAdd);
            this.tabDetail.Controls.Add(this.listDetails);
            this.tabDetail.Location = new System.Drawing.Point(4, 22);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Size = new System.Drawing.Size(650, 303);
            this.tabDetail.TabIndex = 2;
            this.tabDetail.Text = "Варианты исполнения";
            this.tabDetail.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(557, 65);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(90, 25);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Values.Text = "Удалить";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(557, 34);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(90, 25);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Values.Text = "Изменить";
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(557, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(90, 25);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Values.Text = "Добавить";
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // listDetails
            // 
            this.listDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDetails.Location = new System.Drawing.Point(3, 3);
            this.listDetails.Name = "listDetails";
            this.listDetails.Size = new System.Drawing.Size(548, 297);
            this.listDetails.TabIndex = 0;
            // 
            // tabSupplier
            // 
            this.tabSupplier.Controls.Add(this.gridSuppliers);
            this.tabSupplier.Location = new System.Drawing.Point(4, 22);
            this.tabSupplier.Name = "tabSupplier";
            this.tabSupplier.Padding = new System.Windows.Forms.Padding(6);
            this.tabSupplier.Size = new System.Drawing.Size(650, 303);
            this.tabSupplier.TabIndex = 3;
            this.tabSupplier.Text = "Поставщики";
            this.tabSupplier.UseVisualStyleBackColor = true;
            // 
            // gridSuppliers
            // 
            this.gridSuppliers.AllowUserToAddRows = false;
            this.gridSuppliers.AllowUserToDeleteRows = false;
            this.gridSuppliers.AllowUserToResizeColumns = false;
            this.gridSuppliers.AllowUserToResizeRows = false;
            this.gridSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSuppliers.Location = new System.Drawing.Point(6, 6);
            this.gridSuppliers.MultiSelect = false;
            this.gridSuppliers.Name = "gridSuppliers";
            this.gridSuppliers.RowHeadersVisible = false;
            this.gridSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSuppliers.Size = new System.Drawing.Size(638, 291);
            this.gridSuppliers.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
            this.gridSuppliers.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.gridSuppliers.TabIndex = 0;
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.imageMaterial);
            this.tabImage.Location = new System.Drawing.Point(4, 22);
            this.tabImage.Name = "tabImage";
            this.tabImage.Padding = new System.Windows.Forms.Padding(6);
            this.tabImage.Size = new System.Drawing.Size(650, 303);
            this.tabImage.TabIndex = 1;
            this.tabImage.Text = "Изображение";
            this.tabImage.UseVisualStyleBackColor = true;
            // 
            // imageMaterial
            // 
            this.imageMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageMaterial.Header = "";
            this.imageMaterial.Image = ((System.Drawing.Image)(resources.GetObject("imageMaterial.Image")));
            this.imageMaterial.Location = new System.Drawing.Point(6, 6);
            this.imageMaterial.Name = "imageMaterial";
            this.imageMaterial.ShowAddInternetButton = false;
            this.imageMaterial.ShowEditButton = false;
            this.imageMaterial.ShowThumbnails = false;
            this.imageMaterial.Size = new System.Drawing.Size(638, 291);
            this.imageMaterial.SmallButtons = true;
            this.imageMaterial.TabIndex = 0;
            this.imageMaterial.FileNameRequested += new System.EventHandler<ComponentLib.Controls.StringRequestEventArgs>(this.ImageMaterialFileNameRequested);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Все типы (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|BMP (*.bmp)|*.bmp|JP" +
    "EG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";
            // 
            // MaterialEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 395);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(410, 360);
            this.Name = "MaterialEditor";
            this.Text = "MaterialEditor";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboTax)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabCommon.PerformLayout();
            this.tabDetail.ResumeLayout(false);
            this.tabSupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSuppliers)).EndInit();
            this.tabImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textArticleAlt;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textArticle;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkService;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numericMinOrder;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numericBeginRemainder;
        private WorkProject.Controls.SelectBox selectGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboTax;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numericPrice;
        private WorkProject.Controls.SelectBox selectMeasurement;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.TabPage tabImage;
        private ComponentLib.Controls.ImageBox imageMaterial;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabDetail;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox listDetails;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkDetails;
        private System.Windows.Forms.TabPage tabSupplier;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridSuppliers;
    }
}
