//-----------------------------------------------------------------------
// <copyright file="Article.cs" company="Sergey Teplyashin">
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
// <date>14.11.2014</date>
// <time>15:23</time>
// <summary>Defines the Article class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public enum article_content
    {
        material,
        operation,
        product,
        tax,
        none
    }
    
    public enum article_calculation
    {
        content,
        cost,
        profit,
        other,
        price,
        tax,
        summa
    }
    
    public class Article : EntityName
    {
        public virtual int Code { get; set; }
        public virtual article_content Content { get; set; }
        public virtual article_calculation Calculation { get; set; }
        public virtual bool Printable { get; set; }
        public virtual bool ItemsPrintable { get; set; }
        public virtual bool Bolded { get; set; }
        public virtual bool PrintZeroValue { get; set; }
    }
}
