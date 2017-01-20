﻿//-----------------------------------------------------------------------
// <copyright file=ModelGenerator.cs company="Sergey Teplyashin">
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
// <date>24.04.2016</date>
// <time>9:44</time>
// <summary>Defines the ModelGenerator.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Mappings
{
    using System;
    using System.Reflection;
    using FluentNHibernate.Automapping;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    
    public class ModelGenerator
    {
        public AutoPersistenceModel Generate()
        {
            AutoPersistenceModel automap = new AutoPersistenceModel();
            
            automap.Conventions.AddFromAssemblyOf<ModelGenerator>();
            automap.UseOverridesFromAssemblyOf<ModelGenerator>();
                automap.AddEntityAssembly(Assembly.GetAssembly(typeof(Entity)))
                .Where(x => x.Namespace.EndsWith("Entities", StringComparison.CurrentCulture));
            return automap;
        }
    }
}
