//-----------------------------------------------------------------------
// <copyright file="Item.cs" company="Sergey Teplyashin">
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
// <date>17.11.2014</date>
// <time>9:11</time>
// <summary>Defines the Item class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public abstract class Item : Entity
    {
        decimal price;
        decimal count;
        decimal summa;
        
        public virtual decimal Price
        {
            get
            {
                return price;
            }
            
            set
            {
                price = value;
                Summa = CountItems * price;
            }
        }
        
        public virtual decimal CountItems
        {
            get
            {
                return count;
            }
        
            set
            {
                count = value;
                Summa = Price * count;
            }
        }
        
        public virtual decimal Summa
        {
            get
            {
                return summa;
            }
            
            set
            {
                if (summa != value)
                {
                    summa = value;
                    NotifyPropertyChanged("Summa");
                }
            }
        }
    }
}
