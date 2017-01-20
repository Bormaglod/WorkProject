//-----------------------------------------------------------------------
// <copyright file="RepositoryList.cs" company="Sergey Teplyashin">
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
// <date>20.05.2015</date>
// <time>13:43</time>
// <summary>Defines the RepositoryList class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NHibernate;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Infrastructure;
    
    public static class RepositoryList
    {
        public static IRepository<TEntity> Get<TEntity>(ISession session) where TEntity: Entity
        {
            Type repoType = Assembly
                .GetExecutingAssembly()
                .GetType(string.Format(Strings.RepositoryName, typeof(TEntity).Name));
            
            if (repoType != null)
            {
                ConstructorInfo ci = repoType.GetConstructor(new [] { typeof(ISession) });
                return ci.Invoke(new object[] { session }) as Repository<TEntity>;
            }
            
            return new Repository<TEntity>(session);
        }
        
        public static TableProperty Table<T>(ISession session) where T: Entity
        {
            string table_name = DataHelper.GetTableName<T>();
            return Get<TableProperty>(session).Get(table_name);
        }
        
        public static TableProperty Table(ISession session, string entityName)
        {
            string table_name = DataHelper.GetTableName(entityName);
            return Get<TableProperty>(session).Get(table_name);
        }
    }
}
