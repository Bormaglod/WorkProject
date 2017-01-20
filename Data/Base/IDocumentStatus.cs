//-----------------------------------------------------------------------
// <copyright file=IDocumentStatus.cs company="Sergey Teplyashin">
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
// <date>27.04.2016</date>
// <time>9:18</time>
// <summary>Defines the IDocumentStatus class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Base
{
    using System;
    
    public interface IDocumentStatus
    {
        /// <summary>
        /// Свойство определяет отправлен или нет документ.
        /// </summary>
        bool IsSent { get; }
        
        /// <summary>
        /// Свойство определяет есть ли возможность отправки документа.
        /// </summary>
        bool CanSend { get; }
        
        /// <summary>
        /// Метод предназначен для изменения атрибутов документа определяющих,
        /// что он отправлен на указанную дату.
        /// </summary>
        /// <param name="date">Дата и время отправки документа.</param>
        void Send(DateTime date);
    }
}
