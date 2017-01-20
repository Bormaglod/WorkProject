﻿//-----------------------------------------------------------------------
// <copyright file="Entity.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergey-teplyashin@yandex.ru</email>
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
// <date>07.11.2014</date>
// <time>18:26</time>
// <summary>Defines the Entity class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Base
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public abstract class Entity : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        
        public virtual int Id { get; protected set; }
        
        public virtual Entity GetReference(Type type)
        {
            PropertyInfo pi = GetType().GetProperties().FirstOrDefault(p => p.PropertyType == type);
            return pi != null ? pi.GetValue(this, null) as Entity : null;
        }
        
        public virtual Entity GetReference<T>() where T: Entity
        {
            return GetReference(typeof(T));
        }
        
        public virtual void SetReference(Type type, Entity entity)
        {
            PropertyInfo pi = GetType().GetProperties().FirstOrDefault(p => p.PropertyType == type);
            if (pi != null)
            {
                pi.SetValue(this, entity, null);
            }
        }
        
        public virtual void SetReference<T>(T entity) where T: Entity
        {
            SetReference(typeof(T), entity);
        }
        
        public virtual int GetReferenceId(Type type)
        {
            Entity e = GetReference(type);
            return e == null ? 0 : e.Id;
        }
        
        public virtual int GetReferenceId<T>() where T: Entity
        {
            return GetReferenceId(typeof(T));
        }
        
        public virtual void CopyTo(Entity entity)
        {
            if (entity.GetType() != GetType())
            {
                throw new ArgumentException(string.Format("Нельзя копировать объект [{0}] в объект [{1}]", this, entity));
            }
            
            foreach (PropertyInfo p in GetType().GetProperties())
            {
                if (p.PropertyType.GetInterface("IList") != null)
                {
                    IList source = (IList)p.GetValue(this, null);
                    IList dest = (IList)p.GetValue(entity, null);
                    dest.Clear();
                    foreach (var x in source)
                    {
                        dest.Add(x);
                    }
                }
                else if (p.CanWrite)
                {
                    MethodInfo mi = p.GetSetMethod(true);
                    if (mi.IsPublic)
                    {
                        p.SetValue(entity, p.GetValue(this, null), null);
                    }
                }
            }
        }
        
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
