//-----------------------------------------------------------------------
// <copyright file="ProposalEditor.cs" company="Sergey Teplyashin">
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
// <date>22.05.2015</date>
// <time>15:57</time>
// <summary>Defines the ProposalEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using NHibernate.Criterion;
    using WorkProject.Data;
    using WorkProject.Data.Entities;
    using WorkProject.Dialogs;
    using WorkProject.Editors.Base;

    #if DEVELOP
    public partial class ProposalEditor : DocumentMaterialEditor
    #else
    public partial class ProposalEditor : DocumentMaterialEditor<Proposal, ItemProposal>
    #endif
    {
        public ProposalEditor()
        {
            InitializeComponent();
        }
        
        protected override void OnItemDocumentUpdate(ItemProposal item)
        {
            item.Document = Current;
        }
        
        protected override void DoCreateAdditionalTools(ToolStrip tools)
        {
            base.DoCreateAdditionalTools(tools);
            tools.Items.Add(new ToolStripSeparator());
            
            ToolStripDropDownButton menu = new ToolStripDropDownButton(Strings.Fill);
            tools.Items.Add(menu);
            
            /*ToolStripMenuItem plan = new ToolStripMenuItem("...по плану");
            menu.DropDownItems.Add(plan);*/
            
            ToolStripMenuItem list = new ToolStripMenuItem(Strings.FillFromProductList);
            list.Click += CreateListOnProducts;
            menu.DropDownItems.Add(list);
        }
        
        void CreateListOnProducts(object sender, EventArgs e)
        {
            ProductListDialog p = new ProductListDialog();
            
            if (p.ShowDialog(Session))
            {
                Dictionary<MaterialDetail, decimal> materials = new Dictionary<MaterialDetail, decimal>();
                foreach (Specification s in p.Specifications)
                {
                    var list = Session.CreateCriteria<ItemMaterial>().Add(Restrictions.Eq("Specification", s)).List<ItemMaterial>();
                    foreach (var m in list)
                    {
                        decimal materialCount = m.CountItems * p[s];
                        if (materials.ContainsKey(m.MaterialDetail))
                        {
                            materials[m.MaterialDetail] += materialCount;
                        }
                        else
                        {
                            materials.Add(m.MaterialDetail, materialCount);
                        }
                    }
                }
                
                ClearMaterials();
                
                IEnumerable<Supplier> supplier = Session.CreateCriteria<Supplier>()
                    .Add(Restrictions.Eq("Contractor", CurrentContractor))
                    .List<Supplier>();
                
                foreach (MaterialDetail m in materials.Keys)
                {
                    decimal price = m.Material.Price;
                    if (p.AddingOnlySupplierMaterials)
                    {
                        Supplier s = supplier.FirstOrDefault(x => x.Material.Id == m.Material.Id);
                        if (s == null)
                        {
                            continue;
                        }
                        
                        price = s.Material.Price;
                    }
                    
                    decimal c = materials[m];
                    if (p.RoundToMinOrder && m.Material.MinOrder > 0)
                    {
                        c = Math.Round(c / m.Material.MinOrder + 0.5M) * m.Material.MinOrder;
                    }
                    
                    AddNewMaterial(m, price, c);
                }
            }
        }
    }
}
