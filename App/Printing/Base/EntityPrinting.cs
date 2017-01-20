//-----------------------------------------------------------------------
// <copyright file="EntityPrinting.cs" company="Sergey Teplyashin">
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
// <time>10:14</time>
// <summary>Defines the EntityPrinting class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Printing
{
    using System;
    using System.IO;
    using System.IO.Packaging;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.Windows.Xps.Packaging;
    using NHibernate;
    using WorkProject.Data;
    using WorkProject.Data.Base;
    using WorkProject.Utils;
    
    public abstract class EntityPrinting<T> : IPrinting<T> where T: Entity
    {
        T current;
        
        public T Current
        {
            get { return current; }
        }
        
        #region IPrinting implemented
        
        void IPrinting<T>.Print(T entity)
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    ((IPrinting<T>)this).Print(session, entity);
                }
            }
        }
        
        void IPrinting<T>.Print(ISession session, T entity)
        {
            EntityPrint(session, entity);
        }
        
        #endregion
        
        protected abstract string GetPreviewTempate();
        
        protected abstract object GetDataContext(ISession session);
        
        protected abstract void PrepareAdditionalData(ISession session, FlowDocument doc);
        
        void EntityPrint(ISession session, T entity)
        {
            current = entity;
            Preview win = new Preview();
            using (FileStream fs = File.Open(GetPreviewTempate(), FileMode.Open))
            {
                FlowDocument doc = XamlReader.Load(fs) as FlowDocument;
                if (doc != null)
                {
                    doc.PagePadding = new Thickness(
                        ConvertHelper.Sm2Inch(2), 
                        ConvertHelper.Sm2Inch(1), 
                        ConvertHelper.Sm2Inch(1), 
                        ConvertHelper.Sm2Inch(1));
                    doc.PageWidth = ConvertHelper.Sm2Inch(21);
                    doc.PageHeight = ConvertHelper.Sm2Inch(29.7);
                    doc.ColumnWidth = doc.PageWidth;
                    doc.DataContext = GetDataContext(session);
                    
                    PrepareAdditionalData(session, doc);
                    
                    // http://stackoverflow.com/questions/14903362/keeping-bindings-when-putting-a-flowdocument-through-pagination
                    doc.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, new Action(()=>{}));
                    
                    XpsDocument xpsDoc = LoadAsXPS(((IDocumentPaginatorSource)doc).DocumentPaginator, @"memorystream://PreviewTemporary.xps");
                    ((DocumentViewer)win.FindName("docViewer")).Document = xpsDoc.GetFixedDocumentSequence();
                    xpsDoc.Close();
                    win.ShowDialog();
                }
            }
        }
        
        /// <summary>
        /// http://stackoverflow.com/questions/14903362/keeping-bindings-when-putting-a-flowdocument-through-pagination
        /// </summary>
        /// <param name="paginator"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected XpsDocument LoadAsXPS(DocumentPaginator paginator, string name)
        {
            Uri uri = new Uri(name);
            Package docPackage = PackageStore.GetPackage(uri);
            if (docPackage != null)
            {
                PackageStore.RemovePackage(uri);
            }
            MemoryStream stream = new MemoryStream();
            docPackage = Package.Open(stream, FileMode.Create, FileAccess.ReadWrite);
            
            PackageStore.AddPackage(uri, docPackage);
            
            XpsDocument xpsDoc = new XpsDocument(docPackage);
            xpsDoc.Uri = uri;
            
            XpsDocument.CreateXpsDocumentWriter(xpsDoc).Write(paginator);
            
            return xpsDoc;
        }
    }
}
