//-----------------------------------------------------------------------
// <copyright file=WorkProject.cs company="Sergey Teplyashin">
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
// <date>22.04.2016</date>
// <time>13:33</time>
// <summary>Defines the WorkProject class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject
{
    using System;   
    using System.Configuration;
    
    /// <summary>
    /// Configuration section &lt;WorkProject&gt;
    /// </summary>
    /// <remarks>
    /// Assign properties to your child class that has the attribute 
    /// <c>[ConfigurationProperty]</c> to store said properties in the xml.
    /// </remarks>
    public sealed class WorkProjectSettings : ConfigurationSection
    {
        Configuration _Config;

        #region ConfigurationProperties
        
        [ConfigurationProperty("imageFolderName", DefaultValue = "Images")]
        public string ImageFolderName
        {
            get { return (string)this["imageFolderName"]; }
            set { this["imageFolderName"] = value; }
        }
        
        #endregion

        /// <summary>
        /// Private Constructor used by our factory method.
        /// </summary>
        WorkProjectSettings()
        {
            // Allow this section to be stored in user.app. By default this is forbidden.
            this.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToLocalUser;
        }

        #region Public Methods
        
        /// <summary>
        /// Saves the configuration to the config file.
        /// </summary>
        public void Save()
        {
            _Config.Save();
        }
        
        #endregion
        
        #region Static Members
        
        /// <summary>
        /// Gets the current applications &lt;WorkProject&gt; section.
        /// </summary>
        /// <param name="ConfigLevel">
        /// The &lt;ConfigurationUserLevel&gt; that the config file
        /// is retrieved from.
        /// </param>
        /// <returns>
        /// The configuration file's &lt;WorkProject&gt; section.
        /// </returns>
        public static WorkProjectSettings GetSection(ConfigurationUserLevel ConfigLevel)
        {
            /* 
             * This class is setup using a factory pattern that forces you to
             * name the section &lt;WorkProject&gt; in the config file.
             * If you would prefer to be able to specify the name of the section,
             * then remove this method and mark the constructor public.
             */ 
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigLevel);
            WorkProjectSettings oWorkProjectSettings;
            
            oWorkProjectSettings =
                (WorkProjectSettings)Config.GetSection("WorkProjectSettings");
            if (oWorkProjectSettings == null)
            {
                oWorkProjectSettings = new WorkProjectSettings();
                Config.Sections.Add("WorkProjectSettings", oWorkProjectSettings);
            }
            
            oWorkProjectSettings._Config = Config;
            
            return oWorkProjectSettings;
        }
        
        #endregion
    }
}

