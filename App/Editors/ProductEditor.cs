﻿//-----------------------------------------------------------------------
// <copyright file="ProductEditor.cs" company="Sergey Teplyashin">
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
// <date>14.11.2014</date>
// <time>12:58</time>
// <summary>Defines the ProductEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;

    public partial class ProductEditor : ObjectEditor<Product>
    {
        public ProductEditor()
        {
            InitializeComponent();
            ActiveControl = textName;
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textName.Text = Current.Name;
            textFullName.Text = Current.FullName;
            textArticle.Text = Current.ArticleCode;
            textPrice.Text = Current.Price.ToString("0.00");
            textTaxValue.Text = Current.TaxValue.ToString("## '%'");
            textTaxSumma.Text = Current.TaxSumma.ToString("0.00");
            textSumma.Text = Current.Summa.ToString("0.00");
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Name = textName.Text;
            Current.FullName = textFullName.Text.NullIfEmpty();
            Current.ArticleCode = textArticle.Text.NullIfEmpty();
        }
    }
}
