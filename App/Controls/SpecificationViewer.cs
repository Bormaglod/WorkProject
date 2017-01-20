//-----------------------------------------------------------------------
// <copyright file=SpecificationViewer.cs company="Sergey Teplyashin">
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
// <date>02.05.2016</date>
// <time>23:32</time>
// <summary>Defines the SpecificationViewer.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using NHibernate;
    using WorkProject.Data;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Repositories;
    using WorkProject.Dialogs;
    
    public partial class SpecificationViewer : EntityDetailViewer<Product, Specification>
    {
        public SpecificationViewer()
        {
            InitializeComponent();
        }
        
        protected override void CreateAdditionalTools(ISession session)
        {
            base.CreateAdditionalTools(session);
            if (GetGroupType() == typeof(Specification))
            {
                DetailTools.Items.Add(new ToolStripSeparator());
                
                ToolStripSplitButton toolArticles = new ToolStripSplitButton(Strings.Articles);
                DetailTools.Items.Add(toolArticles);
                
                IEnumerable<Article> articles = RepositoryList
                    .Get<Article>(session)
                    .All()
                    .List<Article>()
                    .Where(x => x.Calculation == article_calculation.content)
                    .OrderBy(x => x.Code);
                foreach (Article article in articles)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(article.Name);
                    menuItem.Tag = article;
                    menuItem.Click += ArticleClick;
                    toolArticles.DropDownItems.Add(menuItem);
                }
            }
        }
        
        protected override T RefreshEntity<T>(ISession session, T entity)
        {
            T e = base.RefreshEntity(session, entity);
            if (e != default(T) && CurrentDetail.IsDefault)
            {
                CurrentMaster.SetReference(e);
            }
            
            return e;
        }
        
        void ArticleClick(object sender, EventArgs e)
        {
            IItemsDialog itemsDialog;
            
            Article article = (Article)((ToolStripMenuItem)sender).Tag;
            switch (article.Content)
            {
                case article_content.material:
                    itemsDialog = new SpecificationItemsDialog<ItemMaterial, MaterialDetail>();
                    break;
                case article_content.operation:
                    itemsDialog = new SpecificationItemsDialog<ItemOperation, Operation>();
                    break;
                case article_content.tax:
                    itemsDialog = new SpecificationItemsDialog<ItemTax, Tax>();
                    break;
                case article_content.product:
                    itemsDialog = new SpecificationItemsDialog<ItemProduct, Specification>();
                    break;
                default:
                    throw new Exception("Invalid Current for article_content");
            }
            
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (itemsDialog.ShowDialog(session, CurrentDetail, article))
                        {
                            transaction.Commit();
                            CurrentDetail = RefreshEntity(session, CurrentDetail);
                        }
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        ExceptionHelper.Messsage(exception);
                    }
                }
            }
        }
    }
}
