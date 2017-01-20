//-----------------------------------------------------------------------
// <copyright file="NumberExtension.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergey-teplyashin@yandex.ru</email>
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
// <date>12.11.2014</date>
// <time>21:14</time>
// <summary>Defines the NumberExtension class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Utils
{
    using System;
    
    public static class NumberExtension
    {
        public static int ToInt(this string Current)
        {
            int res;
            return int.TryParse(Current, out res) ? res : 0;
        }
        
        public static decimal ToDecimal(this string Current)
        {
            decimal res;
            return decimal.TryParse(Current, out res) ? res : 0;
        }
        
        public static decimal? ToDecimalOrNull(this string Current)
        {
            decimal res = Current.ToDecimal();
            return res == 0 ? (decimal?)null : res;
        }
        
        public static decimal? Default(this decimal Current)
        {
            return Current == 0 ? (decimal?)null : Current;
        }
        
        public static string ToTextDefault(this decimal? Current)
        {
            return Current.HasValue ? Current.Value.ToString() : string.Empty;
        }
    }
}
