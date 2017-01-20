//-----------------------------------------------------------------------
// <copyright file="DocumentMaterialEditor.cs" company="Sergey Teplyashin">
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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using NHibernate.Criterion;
    using WorkProject.Controls;
    using WorkProject.Data.Entities;
    using WorkProject.Dialogs;
    using WorkProject.Utils;

    #if DEVELOP
    public partial class DocumentMaterialEditor : ObjectEditor<Proposal>
    #else
    public abstract partial class DocumentMaterialEditor<TDocument, TItem> : ObjectEditor<TDocument> 
        where TDocument: Document, new()
        where TItem: ItemDocument, new()
    #endif
    {
        PropertyInfo propContractor;
        BindingList<TItem> items;
        Numerator numerator;
        
        protected DocumentMaterialEditor()
        {
            InitializeComponent();
            CreateAdditionalTools();
            ActiveControl = textNumber;
            gridMaterials.AutoGenerateColumns = false;
            DataGridHelper.CreateColumns<TItem>(gridMaterials);
            #if DEVELOP
            propContractor = typeof(Proposal).GetProperty("Contractor");
            #else
            propContractor = typeof(TDocument).GetProperties().FirstOrDefault(x => x.PropertyType == typeof(Contractor));
            #endif
            
            panelContractor.Visible = propContractor != null;
        }
        
        protected BindingList<TItem> Items { get { return items; } }
        
        protected Contractor CurrentContractor
        {
            get { return selectContractor.GetSelectedEntity<Contractor>(); }
        }
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            numerator = Session.CreateCriteria<Numerator>()
                .Add(
                    Restrictions.Eq("Name", typeof(TDocument).Name)
                   )
                .List<Numerator>().FirstOrDefault();
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            if (propContractor != null)
            {
                selectContractor.LoadEntities<Contractor>();
            }
            
            selectOrganization.LoadEntities<Contractor>(x => x.OurFirm, null);
            
            items = new BindingList<TItem>();
            items.ListChanged += BindingSourceCurrentItemChanged;
            gridMaterials.DataSource = items;
            
            if (numerator == null)
            {
                numerator = new Numerator();
                numerator.Name = typeof(TDocument).Name;
                numerator.DocumentNumber = 1;
            }
            else
            {
                numerator.DocumentNumber++;
            }
            
            textNumber.Text = numerator.DocumentNumber.ToString();
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textNumber.Text = Current.ReferenceNumber.ToString();
            dateDoc.Value = Current.DateCreated;
            
            items = new BindingList<TItem>(
                Session.CreateCriteria<TItem>()
                    .Add(Restrictions.Eq("Document", Current))
                    .List<TItem>());
            items.ListChanged += BindingSourceCurrentItemChanged;
            headerGroup.ValuesSecondary.Description = Current.Summa.ToString("0.00");
            gridMaterials.DataSource = items;
            if (propContractor != null)
            {
                selectContractor.LoadEntities<Contractor>((Contractor)propContractor.GetValue(Current, null));
            }
            
            selectOrganization.LoadEntities<Contractor>(x => x.OurFirm, Current.Organization);
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.ReferenceNumber = textNumber.Text.ToInt();
            Current.DateCreated = dateDoc.Value;
            Current.Organization = selectOrganization.GetSelectedEntity<Contractor>();
            if (propContractor != null)
            {
                propContractor.SetValue(Current, CurrentContractor, null);
            }
            
            if (Current.ReferenceNumber > numerator.DocumentNumber)
            {
                numerator.DocumentNumber = Current.ReferenceNumber;
            }
            
            Session.SaveOrUpdate(numerator);
        }
        
        protected override void OnCommitObject()
        {
            base.OnCommitObject();
            foreach (TItem item in items)
            {
                OnItemDocumentUpdate(item);
                Session.SaveOrUpdate(item);
            }
        }
        
        protected virtual void DoCreateAdditionalTools(ToolStrip tools) {}
        
        protected abstract void OnItemDocumentUpdate(TItem item);
        
        protected void AddNewMaterial(MaterialDetail material, decimal price, decimal count)
        {
            if (Items.FirstOrDefault(x => x.Material == material) == null)
            {
                TItem t = new TItem();
                t.Material = material;
                t.Price = price;
                t.CountItems = count;
                Items.Add(t);
            }
        }
        
        protected void AddNewMaterial(MaterialDetail material, decimal count)
        {
            AddNewMaterial(material, material.Material.Price, count);
        }
        
        protected void ClearMaterials()
        {
            foreach (var i in items)
            {
                Session.Delete(i);
            }
            
            items.Clear();
        }
            
        void BindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            Current.Summa = items.Sum(x => x.Summa);
            headerGroup.ValuesSecondary.Description = Current.Summa.ToString("0.00");
        }
        
        void CreateAdditionalTools()
        {
            DoCreateAdditionalTools(toolStrip1);
        }
        
        void DeleteItems(IEnumerable<MaterialDetail> materials)
        {
            foreach (TItem i in items)
            {
                if (materials.FirstOrDefault(x => x.Id == i.Material.Id) == null)
                {
                    Session.Delete(i);
                    Items.Remove(i);
                }
            }
        }
        
        void ToolAddClick(object sender, EventArgs e)
        {
            var f = new SelectItemsDialog<ItemDocument, MaterialDetail>();
            IEnumerable<MaterialDetail> materials = f.GetItems(Items);
            
            if (materials == null)
            {
                return;
            }
            
            DeleteItems(materials);
            foreach (MaterialDetail m in materials)
            {
                AddNewMaterial(m, m.Material.MinOrder == 0 ? 1 : m.Material.MinOrder);
            }
        }
        
        void ToolRemoveClick(object sender, EventArgs e)
        {
            TItem item = gridMaterials.CurrentItem<TItem>();
            Session.Delete(item);
            Items.Remove(item);
        }
        
        void GridMaterialsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != gridMaterials.ColumnCount - 1)
            {
                TItem item = gridMaterials.CurrentItem<TItem>();
                item.Summa = item.Price * item.CountItems;
            }
        }
    }
}
