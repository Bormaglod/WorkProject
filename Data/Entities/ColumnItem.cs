//-----------------------------------------------------------------------
// <copyright file="ColumnItem.cs" company="Sergey Teplyashin">
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
// <date>28.11.2014</date>
// <time>9:44</time>
// <summary>Defines the ColumnItem class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public enum autosize_mode
    {
        not_set,
        none,
        all_cells = 6,
        all_cells_except_header = 4,
        displayed_cells = 10,
        displayed_cells_except_header = 8,
        column_header = 2,
        fill = 16
    }
    
    public enum alignment
    {
        not_set,
        top_left,
        top_center,
        top_right = 4,
        middle_left = 16,
        middle_center = 32,
        middle_right = 64,
        bottom_left = 256,
        bottom_center = 512,
        bottom_right = 1024
    }
    
    public class ColumnItem : EntityName
    {
        public virtual string Header { get; set; }
        public virtual int Width { get; set; }
        public virtual autosize_mode Mode { get; set; }
        public virtual int FillWeight { get; set; }
        public virtual alignment Alignment { get; set; }
        public virtual string Format { get; set; }
        public virtual bool HideOnGroup { get; set; }
        public virtual int Index { get; set; }
        public virtual TableProperty Table { get; set; }
        public virtual bool Visible { get; set; }
        public virtual int Sorted { get; set; }
        public virtual TableProperty Source { get; set; }
        public virtual bool Frozen { get; set; }
    }
}
