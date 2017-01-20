//-----------------------------------------------------------------------
// <copyright file="SelectBox.cs" company="Sergey Teplyashin">
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
// <date>05.11.2014</date>
// <time>13:38</time>
// <summary>Defines the SelectBox class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using NHibernate;
    using WorkProject.Data;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Repositories;

    public partial class SelectBox : UserControl
    {
        enum LoadingType { None, Default, Where };
        
        public SelectBox()
        {
            InitializeComponent();
            Height = 20;
        }
        
        public TEntity GetSelectedEntity<TEntity>() where TEntity: Entity
        {
            return comboSelect.SelectedItem as TEntity;
        }
        
        public void LoadEntities<TEntity>() where TEntity: Entity
        {
            LoadEntities<TEntity>(default(TEntity));
        }
        
        /// <summary>
        /// Метод заполняет саписок comboSelect значениями из базы данных в соответствии с
        /// условием заданным в predicate.
        /// </summary>
        /// <param name="predicate">Это условие определяет значение по умолчанию (если selectedItem == null) или условие выборки.</param>
        /// <param name="type"></param>
        /// <param name="selectedItem">Значение по умолчанию.</param>
        void LoadEntities<TEntity>(Func<TEntity, bool> predicate, LoadingType type, TEntity selectedItem) where TEntity: Entity
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    IEnumerable<TEntity> items = RepositoryList.Get<TEntity>(session).All().List<TEntity>();
                    TEntity def;
                    if (type == LoadingType.Default)
                    {
                        def = items.FirstOrDefault(predicate);
                    }
                    else
                    {
                        def = selectedItem;
                        if (type == LoadingType.Where)
                        {
                            items = items.Where(predicate);
                        }
                    }
                    
                    comboSelect.Items.AddRange(items.ToArray());
                    if (def != default(TEntity))
                    {
                        comboSelect.SelectedItem = items.FirstOrDefault(x => x.Id == def.Id);
                    }
                }
            }
        }
        
        public void LoadEntities<TEntity>(Func<TEntity, bool> predicateDefaultCurrent) where TEntity: Entity
        {
            LoadEntities(predicateDefaultCurrent, LoadingType.Default, null);
        }
        
        public void LoadEntities<TEntity>(TEntity selectedItem) where TEntity: Entity
        {
            LoadEntities(null, LoadingType.None, selectedItem);
        }
        
        public void LoadEntities<TEntity>(Func<TEntity, bool> predicateWhere, TEntity selectedItem) where TEntity: Entity
        {
            LoadEntities(predicateWhere, LoadingType.Where, selectedItem);
        }
        
        public void LoadGroups<T>() where T: Entity
        {
            LoadGroups<T>(null);
        }
        
        public void LoadGroups<T>(GroupItem @group) where T: Entity
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    IList<GroupItem> list = RepositoryList.Table<T>(session).Groups;
                    comboSelect.Items.AddRange(list.ToArray());
                    comboSelect.SelectedItem = @group == null ? null : list.FirstOrDefault(x => x.Id == @group.Id);
                }
            }
        }
        
        void ButtonComboClearClick(object sender, EventArgs e)
        {
            comboSelect.SelectedItem = null;
        }
    }
}
