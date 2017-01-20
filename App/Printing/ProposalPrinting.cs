//-----------------------------------------------------------------------
// <copyright file="ProposalPrinting.cs" company="Sergey Teplyashin">
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
// <date>10.08.2015</date>
// <time>12:50</time>
// <summary>Defines the ProposalPrinting class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Printing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Documents;
    using NHibernate;
    using NHibernate.Criterion;
    using WorkProject.Data;
    using WorkProject.Data.Entities;
    using WorkProject.Utils;
    
    public class ProposalPrinting : EntityPrinting<Proposal>
    {
        class PrintingData
        {
            public PrintingData(int number, string name, Measurement measurement, decimal count)
            {
                Number = number;
                Name = name;
                Measurement = measurement.Abbreviation;
                Count = count.ToString("0.000");
            }
            
            public int Number { get; set; }
            public string Name { get; set; }
            public string Measurement { get; set; }
            public string Count { get; set; }
        }
        
        protected override string GetPreviewTempate()
        {
            return @"./Printing/PreviewProposal.xaml";
        }
        
        protected override object GetDataContext(ISession session)
        {
            Employee director = session.CreateCriteria<Employee>()
                .Add(Restrictions.Eq("Contractor", Current.Organization))
                .List<Employee>()
                .FirstOrDefault();
            
            return new {
                Current.Organization,
                Current.Contractor,
                Date = Current.DateCreated.ToLongDateString(),
                Number = Current.ReferenceNumber,
                Director = director
            };
        }
        
        protected override void PrepareAdditionalData(ISession session, FlowDocument doc)
        {
            List<PrintingData> printingData = new List<PrintingData>();
            
            IEnumerable<ItemProposal> items = session.CreateCriteria<ItemProposal>()
                .Add(Restrictions.Eq("Document", Current))
                .List<ItemProposal>();
            int num = 1;
            foreach (ItemDocument i in items)
            {
                printingData.Add(new PrintingData(
                    num++,
                    i.Material.ToString(),
                    i.Material.Material.Measurement,
                    i.CountItems));
            }
            
            Table table = doc.FindName("MaterialItems") as Table;
            TableRowGroup rowDetail = doc.FindName("rowDetail") as TableRowGroup;
            
            Type typeData = typeof(PrintingData);
            TableRow templateRow = rowDetail.Rows[0];
            for (int j = 0; j < printingData.Count; j++)
            {
                TableRow r = XamlHelper.CloneTableRow(templateRow);
                
                foreach (TableCell cell in r.Cells)
                {
                    Paragraph paragraph = (Paragraph)cell.Blocks.FirstBlock;
                    InlinePropertyValue inline = (InlinePropertyValue)paragraph.Inlines.FirstInline;
                    string fieldName = inline.PropertyName;
                    PropertyInfo prop = typeData.GetProperty(fieldName);
                    inline.Text = prop == null ? string.Empty : prop.GetValue(printingData[j], null).ToString();
                }
                
                rowDetail.Rows.Add(r);
            }
            
            rowDetail.Rows.Remove(templateRow);
        }
    }
}
