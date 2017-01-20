//-----------------------------------------------------------------------
// <copyright file=MaterialDetailMap.cs company="Sergey Teplyashin">
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
// <date>30.04.2016</date>
// <time>7:06</time>
// <summary>Defines the MaterialDetailMap.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Mappings
{
    using System;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using WorkProject.Data.Entities;
    
    public class MaterialDetailMap : IAutoMappingOverride<MaterialDetail>
    {
        public void Override(AutoMapping<MaterialDetail> mapping)
        {
            mapping.References(x => x.Material).Fetch.Join();
        }
    }
}
