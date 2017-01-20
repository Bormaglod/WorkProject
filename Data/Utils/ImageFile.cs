//-----------------------------------------------------------------------
// <copyright file=ImageFile.cs company="Sergey Teplyashin">
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
// <date>29.04.2016</date>
// <time>22:59</time>
// <summary>Defines the ImageFile.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Utils
{
    using System;
    using System.IO;
    using System.Reflection;
    using WorkProject.Data;
    
    public static class ImageFile
    {
        static string folder = string.Empty;
        
        public static string Folder
        {
            get
            {
                if (string.IsNullOrWhiteSpace(folder))
                {
                    folder = GetFolder();
                }
                
                return folder;
            }
        }
        
        public static string GetFolder()
        {
            string path = DataHelper.Settings.ImageFolder;
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Images";
            }
            
            path = Path.GetFullPath(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            return path;
        }
        
        public static string GetUniqueName(string file)
        {
            int index = 0;
            string name = Path.GetFileNameWithoutExtension(file);
            string ext = Path.GetExtension(file);
            string cont_name = string.Empty;
            
            file = string.Format(@"{0}\{1}{2}{3}", Folder, name, cont_name, ext);
            while (File.Exists(file))
            {
                cont_name = string.Format("_{0}", (index++).ToString("00"));
                file = string.Format(@"{0}\{1}{2}{3}", Folder, name, cont_name, ext);
            }
            
            return string.Format("{0}{1}{2}", name, cont_name, ext);
        }
        
        
    }
}
