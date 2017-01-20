//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Sergey Teplyashin">
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
// <date>22.10.2014</date>
// <time>9:17</time>
// <summary>Defines the Person class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public class Person : EntityGroup
    {
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Name) ?
                GenerateStandardViewName(Surname, FirstName, MiddleName) : 
                base.ToString();
        }
        
        /// <summary>
        /// Метод генерирует отображаемое имя по имени, фамилии и отчеству.
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <returns>Сгенерированное имя вида "Фамилия И.О."</returns>
        public static string GenerateStandardViewName(string surname, string firstName, string middleName)
        {
            string name = surname;
            if (!string.IsNullOrEmpty(firstName))
            {
                name += string.Format(" {0}.", firstName[0]);
                if (!string.IsNullOrEmpty(middleName))
                {
                    name += string.Format(" {0}.", middleName[0]);
                }
            }
            
            return name;
        }
    }
}
