//-----------------------------------------------------------------------
// <copyright file="TableProperty.cs" company="Sergey Teplyashin">
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
// <date>31.10.2014</date>
// <time>15:18</time>
// <summary>Defines the TableProperty class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using WorkProject.Data.Base;
    
    public class TableProperty : EntityName
    {
        public virtual string Title { get; set; }
        public virtual bool HasGroup { get; protected set; }
        public virtual bool HasChild { get; protected set; }
        public virtual bool ShowAllRoot { get; set; }
        public virtual bool RefreshCurrent { get; set; }
        public virtual bool RefreshMaster { get; set; }
        public virtual bool RefreshBefore { get; set; }
        public virtual IList<GroupItem> Groups { get; set; }
        public virtual IList<ColumnItem> Columns { get; set; }
        
        public TableProperty()
        {
            Groups = new List<GroupItem>();
            Columns = new List<ColumnItem>();
        }
    }
}
