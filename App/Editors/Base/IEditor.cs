//-----------------------------------------------------------------------
// <copyright file="IEditor.cs" company="Sergey Teplyashin">
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
// <date>31.10.2014</date>
// <time>14:28</time>
// <summary>Defines the IEditor interface.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors.Base
{
    using System;
    using WorkProject.Controls;
    using WorkProject.Data.Base;
    
    public interface IEditor<T> where T: Entity
    {
        T CreateObject();
        T CreateObject(T fromEntity);
        T CreateObject(Entity owner);
        
        T CreateObject(IViewer viewer);
        T CreateObject(IViewer viewer, T fromEntity);
        T CreateObject(IViewer viewer, Entity owner);
        
        T Edit(int id);
        T Edit(int id, Entity masterEntity);
    }
}
