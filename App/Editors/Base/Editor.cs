//-----------------------------------------------------------------------
// <copyright file="Editor.cs" company="Sergey Teplyashin">
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
// <date>26.11.2014</date>
// <time>14:56</time>
// <summary>Defines the Editor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors.Base
{
    using System;
    using System.Reflection;
    using NHibernate;
    using WorkProject.Data.Base;
    
    public static class Editor
    {
        public static IEditor<T> Get<T>() where T: Entity
        {
            Type editorType = Type.GetType(string.Format(Strings.EditorName, typeof(T).Name), false, true);
            if (editorType != null)
            {
                ConstructorInfo ci = editorType.GetConstructor(Type.EmptyTypes);
                return ci.Invoke(null) as IEditor<T>;
            }
            
            return null;
        }
    }
}
