//-----------------------------------------------------------------------
// <copyright file="Proposal.cs" company="Sergey Teplyashin">
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
// <date>18.05.2015</date>
// <time>10:51</time>
// <summary>Defines the Proposal class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Data.Entities
{
    using System;
    using WorkProject.Data.Base;
    
    public class Proposal : Document, IDocumentStatus
    {
        public virtual Contractor Contractor { get; set; }
        public virtual DateTime? DateSend { get; set; }
        
        public virtual string SendStatus
        {
            get { return ((IDocumentStatus)this).IsSent ? DateSend.Value.ToString() : Strings.DoNotSend; }
        }
        
        public virtual string Email
        {
            get { return Contractor == null ? string.Empty : Contractor.Email; }
        }
        
        #region ISend implemented
        
        bool IDocumentStatus.IsSent
        {
            get { return DateSend != null; }
        }
        
        bool IDocumentStatus.CanSend
        {
            get { return !string.IsNullOrWhiteSpace(Email); }
        }
        
        void IDocumentStatus.Send(DateTime date)
        {
            DateSend = date;
        }
        
        #endregion
    }
}
