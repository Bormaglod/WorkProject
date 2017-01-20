//-----------------------------------------------------------------------
// <copyright file="SpecificationPrinting.cs" company="Sergey Teplyashin">
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
// <date>10.08.2015</date>
// <time>10:12</time>
// <summary>Defines the SpecificationPrinting class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Printing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Documents;
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Criterion;
    using WorkProject.Data;
    using WorkProject.Data.Entities;
    
    public class SpecificationPrinting : EntityPrinting<Specification>
    {
        protected override string GetPreviewTempate()
        {
            return @"./Printing/PreviewCalculation.xaml";
        }

        protected override object GetDataContext(ISession session)
        {
            return new {
                        Current.Product.Name,
                        Specification = Current.Name,
                        Current.DateApproval
                    };
        }
        
        protected override void PrepareAdditionalData(ISession session, FlowDocument doc)
        {
            var printingData = new List<dynamic>();
            var articles = from i in session.Query<Article>()
                orderby i.Code
                select i;
            
            IEnumerable<ItemSpecification> items = null;
            foreach (Article article in articles)
            {
                if (!article.Printable)
                {
                    continue;
                }
                
                decimal summa = 0;
                string count = string.Empty;
                switch (article.Calculation)
                {
                    case article_calculation.content:
                    case article_calculation.other:
                        items = session.CreateCriteria<ItemSpecification>()
                            .Add(Restrictions.Eq("Article", article))
                            .Add(Restrictions.Eq("Specification", Current))
                            .List<ItemSpecification>();
                        summa = items.Sum(x => x.Summa);
                        break;
                    case article_calculation.cost:
                        summa = Current.Cost;
                        break;
                    case article_calculation.profit:
                        summa = Current.Profit;
                        count = Current.ProfitPercent.ToString("0.0\\%");
                        break;
                    case article_calculation.price:
                        summa = Current.Price;
                        break;
                    case article_calculation.tax:
                        summa = Current.TaxSumma;
                        count = Current.TaxValue.ToString("0.0\\%");
                        break;
                    case article_calculation.summa:
                        summa = Current.Summa;
                        break;
                    default:
                        throw new Exception("Invalid value for article_type");
                }
                
                if (!article.PrintZeroValue && summa == 0)
                {
                    continue;
                }
                
                ArticleStringStyleSelector.ArticleStyle style = article.Bolded ? ArticleStringStyleSelector.ArticleStyle.Summary : ArticleStringStyleSelector.ArticleStyle.Normal;
                
                printingData.Add(new {
                                     article.Code,
                                     article.Name,
                                     Count = count,
                                     Summa = summa.ToString("0.00"),
                                     ArticleStyle = style });
                int code = article.Code + 1;
                if (items != null && article.ItemsPrintable)
                {
                    foreach (ItemSpecification item in items)
                    {
                        count = string.Empty;
                        switch (article.Content)
                        {
                            case article_content.material:
                                count = item.CountItems.ToString("0.000");
                                break;
                            case article_content.operation:
                                count = item.CountItems.ToString("0.000");
                                break;
                            case article_content.tax:
                                count = item.CountItems.ToString("0.0\\%");
                                break;
                        }
                        
                        printingData.Add(new {
                                             Code = code++,
                                             Name = item.GetSpecificationRef().ToString(),
                                             Count = count,
                                             Summa = item.Summa.ToString("0.00"),
                                             ArticleStyle = ArticleStringStyleSelector.ArticleStyle.Detail
                                         });
                    }
                }
            }
            
            System.Windows.Controls.ListView lv = doc.FindName("listArticles") as System.Windows.Controls.ListView;
            lv.ItemsSource = printingData;
        }
    }
}
