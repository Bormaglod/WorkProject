//-----------------------------------------------------------------------
// <copyright file=XamlHelper.cs company="Sergey Teplyashin">
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
// <date>20.04.2016</date>
// <time>21:16</time>
// <summary>Defines the XamlHelper.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Utils
{
    using System;
    using System.IO;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.Xml;
    
    public static class XamlHelper
    {
        /// <summary>
        /// Loads a XAML object from string
        /// </summary>
        /// <param name="s">string containing the XAML object</param>
        /// <returns>XAML object or null, if string was empty</returns>
        public static object LoadXamlFromString(string s)
        {
            if (String.IsNullOrEmpty(s)) return null;
            StringReader stringReader = new StringReader(s);
            XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings());
            return XamlReader.Load(xmlReader);
        }
        
        /// <summary>
        /// Clones a table row
        /// </summary>
        /// <param name="orig">original table row</param>
        /// <returns>cloned table row</returns>
        public static TableRow CloneTableRow(TableRow orig)
        {
            return orig == null ? null : (TableRow)LoadXamlFromString(XamlWriter.Save(orig));
        }
    }
}
