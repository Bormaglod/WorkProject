//-----------------------------------------------------------------------
// <copyright file=ItemDocumentComparer.cs company="Sergey Teplyashin">
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
// <date>06.05.2016</date>
// <time>15:32</time>
// <summary>Defines the ItemDocumentComparer class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Base
{
    using System;
    using System.Collections.Generic;
    using WorkProject.Data.Entities;
    
    public class ItemDocumentComparer<T> : IEqualityComparer<T> where T: ItemDocument
    {
        public bool Equals(T x, T y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;
            
            return x.GetDocumentRef().Id == y.GetDocumentRef().Id;
        }
        
        public int GetHashCode(T item)
        {
            if (object.ReferenceEquals(item, null))
                return 0;
            
            return item.GetDocumentRef().GetHashCode();
        }
    }
}
