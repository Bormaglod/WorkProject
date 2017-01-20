//-----------------------------------------------------------------------
// <copyright file="MainPanel.cs" company="Sergey Teplyashin">
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
// <time>14:03</time>
// <summary>Defines the MainPanel class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;
    using WorkProject.Data.Base;
    
    public enum ViewWindow { Company, Viewer }
    
    public partial class MainPanel : UserControl
    {
        ViewWindow view;
        Control viewer;
        
        public MainPanel()
        {
            InitializeComponent();
            company.Dock = DockStyle.Fill;
            view = ViewWindow.Company;
        }
        
        public ViewWindow ViewWindow
        {
            get
            {
                return view;
            }
            
            set
            {
                if (view != value)
                {
                    view = value;
                    if (viewer != null)
                    {
                        viewer.Visible = view == ViewWindow.Viewer;
                    }
                    
                    company.Visible = view == ViewWindow.Company;
                }
            }
        }
        
        public void Fill<T>() where T: Entity
        {
            Control old = viewer;
            viewer = new EntityViewer<T>();
            viewer.Dock = DockStyle.Fill;
            Controls.Add(viewer);
            
            ViewWindow = ViewWindow.Viewer;
            
            if (old != null && Controls.Contains(old))
            {
                Controls.Remove(old);
            }
        }
        
        public void Fill<TContent, TInfo>()
            where TContent: Entity
            where TInfo: Entity, ITreeItem
        {
            Control old = viewer;
            
            Type editorType = Type.GetType(string.Format(Strings.ViewerName, typeof(TInfo).Name), false, true);
            if (editorType != null)
            {
                ConstructorInfo ci = editorType.GetConstructor(Type.EmptyTypes);
                viewer = ci.Invoke(null) as Control;
            }
            else
            {
                viewer = new EntityDetailViewer<TContent, TInfo>();
            }
            
            viewer.Dock = DockStyle.Fill;
            Controls.Add(viewer);
            
            ViewWindow = ViewWindow.Viewer;
            
            if (old != null && Controls.Contains(old))
            {
                Controls.Remove(old);
            }
        }
    }
}
