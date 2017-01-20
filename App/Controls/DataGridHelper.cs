//-----------------------------------------------------------------------
// <copyright file="DataGridHelper.cs" company="Sergey Teplyashin">
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
// <date>17.11.2014</date>
// <time>12:51</time>
// <summary>Defines the DataGridHelper class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using Inflector;
    using NHibernate;
    using WorkProject.Data;
    using WorkProject.Data.Base;
    using WorkProject.Data.Entities;
    using WorkProject.Data.Repositories;
    
    public static class DataGridHelper
    {
        public static TItem CurrentItem<TItem>(this DataGridView grid)
        {
            BindingList<TItem> items = grid.DataSource as BindingList<TItem>;
            if (items != null)
            {
                int row = grid.CurrentRow.Index;
                if (row != -1)
                {
                    return items[row];
                }
            }
            
            return default(TItem);
        }
        
        public static void CreateColumns<T>(DataGridView grid) where T: Entity
        {
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    CreateColumns(grid, RepositoryList.Table<T>(session));
                }
            }
        }
        
        public static void CreateColumns(DataGridView grid, TableProperty table)
        {
            grid.Columns.Clear();
            List<DataGridViewColumn> hideColumns = new List<DataGridViewColumn>();
            
            SortedList<int, DataGridViewColumn> columns = new SortedList<int, DataGridViewColumn>();
            
            foreach (ColumnItem c in table.Columns)
            {
                DataGridViewColumn column;
                if (c.Source != null)
                {
                    column = CreateComboColumn(c);
                }
                else
                {
                    column = CreateTextColumn(c);
                }
                
                if (c.Index == 0)
                {
                    grid.Columns.Add(column);
                }
                else
                {
                    columns.Add(c.Index, column);
                }
                
                column.ReadOnly = c.Frozen;
            }
            
            foreach (int c in columns.Keys)
            {
                grid.Columns.Add(columns[c]);
            }
        }
        
        static DataGridViewColumn CreateTextColumn(ColumnItem c)
        {
            KryptonDataGridViewTextBoxColumn column = new KryptonDataGridViewTextBoxColumn();
            FillCommonProperties(column, c);
            return column;
        }
        
        static DataGridViewColumn CreateComboColumn(ColumnItem c)
        {
            KryptonDataGridViewComboBoxColumn column = new KryptonDataGridViewComboBoxColumn();
            FillCommonProperties(column, c);
            column.DropDownStyle = ComboBoxStyle.DropDownList;
            
            string sourceName = c.Source.Name.Pascalize();
            using (var session = DataHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var element in session.CreateCriteria(sourceName).List())
                    {
                        column.Items.Add(element.ToString());
                    }
                }
            }
            
            Type contentType = Assembly
                .GetExecutingAssembly()
                .GetType(string.Format(Strings.EntityName, sourceName));
            column.ValueType = contentType;
            
            return column;
        }
        
        static void FillCommonProperties(DataGridViewColumn column, ColumnItem c)
        {
            column.HeaderText = c.Header;
            column.Name = c.Name;
            column.AutoSizeMode = (DataGridViewAutoSizeColumnMode)((int)c.Mode);
            column.Width = c.Width;
            column.FillWeight = c.FillWeight;
            column.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)((int)c.Alignment);
            column.DefaultCellStyle.Format = c.Format;
            column.DataPropertyName = c.Name;
            column.Visible = c.Visible;
            column.Tag = c;
        }
    }
}
