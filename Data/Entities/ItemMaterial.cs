﻿//-----------------------------------------------------------------------
// <copyright file="ItemMaterial.cs" company="Sergey Teplyashin">
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
// <date>17.11.2014</date>
// <time>9:14</time>
// <summary>Defines the ItemMaterial class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public class ItemMaterial : ItemSpecification
    {
        public virtual MaterialDetail MaterialDetail { get; set; }
        
        public override Entity GetSpecificationRef()
        {
            return MaterialDetail;
        }
    }
}
