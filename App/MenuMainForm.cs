//-----------------------------------------------------------------------
// <copyright file="MenuMainForm.cs" company="Sergey Teplyashin">
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
// <date>22.10.2014</date>
// <time>12:50</time>
// <summary>Defines the MenuMainForm class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject
{
    using System;
    using System.Drawing;
    using Qios.DevSuite.Components;
    using Qios.DevSuite.Components.Ribbon;

    public sealed partial class MenuMainForm : QRibbonMenuWindow
    {
        readonly QCompositeMenuItem qMenuSave;
        readonly QCompositeMenuItem qMenuLoad;
        readonly QCompositeMenuItem qMenuExit;
        
        public MenuMainForm()
        {
            InitializeComponent();
            
            qMenuSave = new QCompositeMenuItem();
            qMenuSave.Configuration.IconConfiguration.IconSize = new Size(32, 32);
            qMenuSave.Configuration.Padding = new QPadding(5, 1, 1, 1);
            //this.qMenuSave.Icon = Resources.Save;
            qMenuSave.Title = "Сохранить в XML";
            
            qMenuLoad = new QCompositeMenuItem();
            qMenuLoad.Configuration.IconConfiguration.IconSize = new Size(32, 32);
            qMenuLoad.Configuration.Padding = new QPadding(5, 1, 1, 1);
            //this.qMenuLoad.Icon = Resources.Folder_Yellow;
            qMenuLoad.Title = "Загрузить из XML";
            
            qMenuExit = new QCompositeMenuItem();
            qMenuExit.Configuration.IconConfiguration.IconSize = new Size(32, 32);
            qMenuExit.Configuration.Padding = new QPadding(5, 1, 1, 1);
            //this.qMenuExit.Icon = Resources.exit;
            qMenuExit.Title = "Выход";
            
            Items.Add(this.qMenuSave);
            Items.Add(this.qMenuLoad);
            Items.Add(new QCompositeSeparator());
            Items.Add(this.qMenuExit);
        }
    }
}
