//-----------------------------------------------------------------------
// <copyright file="Material.cs" company="Sergey Teplyashin">
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
// <date>07.11.2014</date>
// <time>13:29</time>
// <summary>Defines the Material class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public class Material : EntityGroup
    {
        public virtual Measurement Measurement { get; set; }
        public virtual decimal Price { get; set; }
        public virtual short TaxValue { get; set; }
        public virtual bool Service { get; set; }
        public virtual decimal BeginRemainder { get; set; }
        public virtual decimal MinOrder { get; set; }
        public virtual string ArticleCode { get; set; }
        public virtual string AltArticleCode { get; set; }
        public virtual Image Image { get; set; }
        public virtual bool HasDetails { get; set; }
    }
}
