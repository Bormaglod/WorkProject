//-----------------------------------------------------------------------
// <copyright file="Specification.cs" company="Sergey Teplyashin">
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
// <date>13.11.2014</date>
// <time>12:54</time>
// <summary>Defines the Specification class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public enum calculation_method
    {
        /// <summary>
        /// Расчет прибыли в процентах от себестоимости
        /// </summary>
        profit,
        
        /// <summary>
        /// Расчет процента прибыли как разницы между ценой и себестоимостью
        /// </summary>
        price
    }
    
    public class Specification : EntityName, ITreeItem, IResource
    {
        public virtual Product Product { get; set; }
        public virtual DateTime DateApproval { get; set; }
        public virtual string CommentText { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual decimal Profit { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal ProfitPercent { get; set; }
        public virtual calculation_method CalcPriceMethod { get; set; }
        public virtual short TaxValue { get; set; }
        public virtual decimal TaxSumma { get; set; }
        public virtual decimal Summa { get; set; }
        public virtual bool IsDefault { get; set; }
        
        #region ITreeItem implemented
        
        int? ITreeItem.Parent_Id { get; set; }
        
        #endregion
        
        #region IResource implemented
        
        ITreeItem IResource.Group
        {
            get { return Product; }
        }
        
        decimal IResource.Price
        {
            get { return Cost; }
        }
        
        decimal IResource.DefaultCountItems
        {
            get { return 1; }
        }
        
        #endregion
    }
}
