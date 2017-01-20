//-----------------------------------------------------------------------
// <copyright file="CountItemsEventArgs.cs" company="Sergey Teplyashin">
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
// <date>06.05.2015</date>
// <time>10:29</time>
// <summary>Defines the CountItemsEventArgs class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using WorkProject.Data.Base;
    
    public class CountItemsEventArgs : EventArgs
    {
        readonly ITreeItem itemTree;
        
        public CountItemsEventArgs(ITreeItem item)
        {
            itemTree = item;
            CountItems = 0;
        }
        
        public int CountItems { get; set; }
        
        public ITreeItem ItemTree
        {
            get { return itemTree; }
        }
    }
}
