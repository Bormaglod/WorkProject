//-----------------------------------------------------------------------
// <copyright file="ArticleStringStyleSelector.cs" company="Sergey Teplyashin">
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
// <date>08/21/2014</date>
// <time>09:51</time>
// <summary>Defines the ArticleStringStyleSelector class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Printing
{
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
                 
    public class ArticleStringStyleSelector : StyleSelector
    {
        public enum ArticleStyle { Normal, Detail, Summary }
        
        public Style DefaultStyle { get; set; }
        
        public Style DetailStyle { get; set; }
        
        public Style SummaryStyle { get; set; }
        
        public string Property { get; set; }
        
        public override Style SelectStyle(object item, DependencyObject container)
        {
            Type type = item.GetType();
            PropertyInfo info = type.GetProperty(Property);
            if (info != null)
            {
                switch ((ArticleStyle)info.GetValue(item, null))
                {
                    case ArticleStyle.Detail:
                        return DetailStyle;
                    case ArticleStyle.Summary:
                        return SummaryStyle;
                    default:
                        return DefaultStyle;
                }
                
            }
            return base.SelectStyle(item, container);
        }
    }
}
