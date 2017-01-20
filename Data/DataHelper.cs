//-----------------------------------------------------------------------
// <copyright file="DataHelper.cs" company="Sergey Teplyashin">
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
// <date>19.09.2014</date>
// <time>8:39</time>
// <summary>Defines the DataHelper class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data
{
    using System;
    using System.Configuration;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Persister.Entity;
    using WorkProject.Data.Base;
    using WorkProject.Data.Configuration;
    using WorkProject.Data.Mappings;
    
    public static class DataHelper
    {
        static ISessionFactory sessionFactory;
        static WorkProjectSettings settings = WorkProjectSettings.GetSection(ConfigurationUserLevel.None);
        
        public static ISessionFactory SessionFactory
        {
            get
            {
                if(sessionFactory == null)
                {
                    sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.PostgreSQL82
                            .ConnectionString(c => c
                                  .FromConnectionStringWithKey("Postgres"))
                            .ShowSql())
                        .Mappings(x => x.AutoMappings.Add(new ModelGenerator().Generate()))
                        .ExposeConfiguration(x => x.SetInterceptor(new SqlStatementInterceptor()))
                        .BuildSessionFactory();
                }
                
                return sessionFactory;
            }
        }
        
        public static WorkProjectSettings Settings
        {
            get { return settings; }
        }
        
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        
        public static string GetTableName<T>() where T: Entity
        {
            return GetTableName(typeof(T).Name);
        }
        
        public static string GetTableName(string entityName)
        {
            AbstractEntityPersister persister = (AbstractEntityPersister)DataHelper.SessionFactory.GetClassMetadata(string.Format(Strings.EntityName, entityName));
            return persister.TableName;
        }
    }
}
