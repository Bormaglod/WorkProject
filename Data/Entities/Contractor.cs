//-----------------------------------------------------------------------
// <copyright file="Contractor.cs" company="Sergey Teplyashin">
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
// <date>16.10.2014</date>
// <time>14:27</time>
// <summary>Defines the Contractor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public class Contractor : EntityGroup, ITreeItem
    {
        public virtual string ShortName { get; set; }
        public virtual string FullName { get; set; }
        public virtual Okopf Okopf { get; set; }
        public virtual decimal? INN { get; set; }
        public virtual decimal KPP { get; set; }
        public virtual decimal? OGRN { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Web { get; set; }
        public virtual decimal? OKPO { get; set; }
        public virtual decimal? Account { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual bool OurFirm { get; set; }
        int? ITreeItem.Parent_Id { get; set; }
        
        public override void CopyTo(Entity entity)
        {
            base.CopyTo(entity);
            (entity as Contractor).INN = null;
        }
    }
}
