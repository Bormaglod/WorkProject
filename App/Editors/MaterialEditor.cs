//-----------------------------------------------------------------------
// <copyright file="MaterialEditor.cs" company="Sergey Teplyashin">
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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Controls;
    using NHibernate.Criterion;
    using WorkProject.Controls;
    using WorkProject.Data;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Infrastructure;
    using WorkProject.Data.Repositories;
    using WorkProject.Data.Utils;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;

    public partial class MaterialEditor : ObjectEditor<Material>
    {
        TabPage detailPage;
        
        public MaterialEditor()
        {
            InitializeComponent();
            ActiveControl = textName;
            detailPage = tabDetail;
        }
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            gridSuppliers.AutoGenerateColumns = false;
            DataGridHelper.CreateColumns<Supplier>(gridSuppliers);
            gridSuppliers.Columns["Material"].Visible = false;
            
            DataGridViewColumn c = gridSuppliers.Columns["Contractor"];
            gridSuppliers.Columns.Remove(c);
            
            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c.DisplayIndex = 0;
            gridSuppliers.Columns.Insert(0, c);
            
            MaterialDetail.ViewMode = MaterialDetail.Mode.OnlyName;
        }
        
        protected override void OnFinalize()
        {
            base.OnFinalize();
            MaterialDetail.ViewMode = MaterialDetail.Mode.FullName;
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            selectMeasurement.LoadEntities<Measurement>(x => x.IsDefault);
            selectGroup.LoadGroups<Material>(Viewer == null ? null : Viewer.CurrentGroup as GroupItem);
            comboTax.SelectedIndex = 2;
            checkDetails.Checked = false;
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textName.Text = Current.Name;
            selectMeasurement.LoadEntities<Measurement>(Current.Measurement);
            numericPrice.Value = Current.Price;
            comboTax.SelectedIndex = Current.TaxValue == 0 ? 0 : (Current.TaxValue == 10 ? 1 : 2);
            selectGroup.LoadGroups<Material>(Current.Group);
            numericBeginRemainder.Value = Current.BeginRemainder;
            numericMinOrder.Value = Current.MinOrder;
            textArticle.Text = Current.ArticleCode;
            textArticleAlt.Text = Current.AltArticleCode;
            checkService.Checked = Current.Service;
            checkDetails.Checked = Current.HasDetails;
            if (Current.Image != null)
            {
                imageMaterial.AddImage(Current.Image.Dest);
            }
            
            listDetails.Items.AddRange(
                Session.CreateCriteria<MaterialDetail>()
                    .Add(Restrictions.Eq("Material", Current))
                    .List<MaterialDetail>()
                    .ToArray());
            
            gridSuppliers.DataSource = Session.CreateCriteria<Supplier>().Add(Restrictions.Eq("Material", Current)).List();
            
            UpdateDetailsPage();
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Name = textName.Text;
            Current.Measurement = selectMeasurement.GetSelectedEntity<Measurement>();
            Current.Price = numericPrice.Value;
            if (comboTax.SelectedIndex != -1)
            {
                Current.TaxValue = (new short[] { 0, 10, 18 })[comboTax.SelectedIndex];
            }
            
            Current.Group = selectGroup.GetSelectedEntity<GroupItem>();
            Current.BeginRemainder = numericBeginRemainder.Value;
            Current.MinOrder = numericMinOrder.Value;
            Current.Service = checkService.Checked;
            Current.ArticleCode = textArticle.Text.NullIfEmpty();
            Current.AltArticleCode = textArticleAlt.Text.NullIfEmpty();
            
            if (imageMaterial.ImageFileChanged)
            {
                string file = imageMaterial.CurrentImageFileName;
                IRepository<Image> repo = RepositoryList.Get<Image>(Session);
                IList<Image> images = repo.All().List<Image>();
                Image image = null;
                if (!imageMaterial.IsEmptyImageFile)
                {
                    if (Path.GetDirectoryName(file).ToLower() == ImageFile.Folder.ToLower())
                    {
                        image = images.FirstOrDefault(x => x.Name == Path.GetFileName(file));
                        if (image == null)
                        {
                            image = new Image();
                            image.Source = null;
                            image.Name = Path.GetFileName(file);
                        }
                    }
                    else
                    {
                        image = images.FirstOrDefault(x => x.Source == file);
                        if (image == null)
                        {
                            image = new Image();
                            image.Source = file;
                            image.Name = ImageFile.GetUniqueName(file);
                            File.Copy(file, image.Dest);
                        }
                    }
                }
                
                Current.Image = image;
            }
        }
        
        void UpdateDetailsPage()
        {
            if (checkDetails.Checked)
            {
                if (!tabControl1.TabPages.Contains(detailPage))
                {
                    tabControl1.TabPages.Insert(1, detailPage);
                }
            }
            else
            {
                if (tabControl1.TabPages.Contains(detailPage))
                {
                    tabControl1.TabPages.Remove(detailPage);
                }
            }
        }
        
        void ImageMaterialFileNameRequested(object sender, StringRequestEventArgs e)
        {
            openFileDialog1.InitialDirectory = DataHelper.Settings.ImageFolder;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                e.RequestValue = openFileDialog1.FileName;
            }
        }
        
        void ButtonAddClick(object sender, EventArgs e)
        {
            string detailName = KryptonInputBox.Show(this, Strings.InputVariant, Strings.Variant, string.Empty);
            if (!string.IsNullOrWhiteSpace(detailName))
            {
                MaterialDetail detail = new MaterialDetail();
                detail.Name = detailName;
                detail.Material = Current;
                
                RepositoryList.Get<MaterialDetail>(Session).AddOrUpdate(detail);
                listDetails.Items.Add(detail);
            }
        }
        
        void ButtonEditClick(object sender, EventArgs e)
        {
            if (listDetails.SelectedItem != null)
            {
                MaterialDetail detail = (MaterialDetail)listDetails.SelectedItem;
                string detailName = KryptonInputBox.Show(this, Strings.InputVariant, Strings.Variant, detail.Name);
                if (detailName != detail.Name && !string.IsNullOrWhiteSpace(detailName))
                {
                    RepositoryList.Get<MaterialDetail>(Session).AddOrUpdate(detail);
                    detail.Name = detailName;
                }
            }
        }
        
        void ButtonDeleteClick(object sender, EventArgs e)
        {
            MaterialDetail detail = (MaterialDetail)listDetails.SelectedItem;
            RepositoryList.Get<MaterialDetail>(Session).Delete(detail);
            listDetails.Items.Remove(detail);
        }
        
        void CheckDetailsCheckedChanged(object sender, EventArgs e)
        {
            UpdateDetailsPage();
        }
    }
}
