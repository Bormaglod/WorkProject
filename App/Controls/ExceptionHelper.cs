//-----------------------------------------------------------------------
// <copyright file=ExceptionHelper.cs company="NIIAR">
//     Copyright (c) 2016 АО ГНЦ "НИИАР". All rights reserved.
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
// <date>27.04.2016</date>
// <time>13:52</time>
// <summary>Defines the ExceptionHelper class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Windows.Forms;
    using Npgsql;
    using ComponentFactory.Krypton.Toolkit;
    
    public static class ExceptionHelper
    {
        public static void Messsage(Exception exception)
        {
            NpgsqlException npgsqlException = exception.InnerException as NpgsqlException;
            string message = npgsqlException == null ? exception.Message : npgsqlException.BaseMessage;
            KryptonMessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
