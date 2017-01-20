//-----------------------------------------------------------------------
// <copyright file="ContractorEditor.cs" company="Sergey Teplyashin">
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
// <date>05.11.2014</date>
// <time>13:13</time>
// <summary>Defines the ContractorEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using NHibernate.Criterion;
    using WorkProject.Controls;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;

    public partial class ContractorEditor : ObjectEditor<Contractor>
    {
        public ContractorEditor()
        {
            InitializeComponent();
            ActiveControl = textName;
        }
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            gridEmployees.AutoGenerateColumns = false;
            gridMaterials.AutoGenerateColumns = false;
            DataGridHelper.CreateColumns<Employee>(gridEmployees);
            DataGridHelper.CreateColumns<Supplier>(gridMaterials);
            gridMaterials.Columns["Contractor"].Visible = false;
            gridEmployees.Columns["Contractor"].Visible = false;
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            selectBank.LoadEntities<Bank>();
            selectGroup.LoadGroups<Contractor>(Viewer == null ? null : Viewer.CurrentGroup as GroupItem);
            selectOkopf.LoadEntities<Okopf>();
        }

        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textName.Text = Current.Name;
            textShortName.Text = Current.ShortName;
            textFullName.Text = Current.FullName;
            textAddress.Text = Current.Address;
            textPhone.Text = Current.Phone;
            textFax.Text = Current.Fax;
            textEmail.Text = Current.Email;
            textWeb.Text = Current.Web;
            textAccount.Text = Current.Account.ToTextDefault();
            selectBank.LoadEntities<Bank>(Current.Bank);
            selectGroup.LoadGroups<Contractor>(Current.Group);
            selectOkopf.LoadEntities<Okopf>(Current.Okopf);
            textInn.Text = Current.INN.ToTextDefault();
            textKpp.Text = Current.KPP.ToString();
            textOgrn.Text = Current.OGRN.ToTextDefault();
            textOkpo.Text = Current.OKPO.ToTextDefault();
            checkOurFirm.Checked = Current.OurFirm;
            gridEmployees.DataSource = Session.CreateCriteria<Employee>().Add(Restrictions.Eq("Contractor", Current)).List();
            gridMaterials.DataSource = Session.CreateCriteria<Supplier>().Add(Restrictions.Eq("Contractor", Current)).List();
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Account = textAccount.Text.ToDecimalOrNull();
            Current.Address = textAddress.Text.NullIfEmpty();
            Current.Bank = selectBank.GetSelectedEntity<Bank>();
            Current.Email = textEmail.Text.NullIfEmpty();
            Current.Web = textWeb.Text.NullIfEmpty();
            Current.Fax = textFax.Text.NullIfEmpty();
            Current.FullName = textFullName.Text.NullIfEmpty();
            Current.Group = selectGroup.GetSelectedEntity<GroupItem>();
            Current.INN = textInn.Text.ToDecimalOrNull();
            Current.KPP = textKpp.Text.ToDecimal();
            Current.Name = textName.Text.NullIfEmpty();
            Current.OGRN = textOgrn.Text.ToDecimalOrNull();
            Current.Okopf = selectOkopf.GetSelectedEntity<Okopf>();
            Current.OKPO = textOkpo.Text.ToDecimalOrNull();
            Current.OurFirm = checkOurFirm.Checked;
            Current.Phone = textPhone.Text.NullIfEmpty();
            Current.ShortName = textShortName.Text.NullIfEmpty();
        }
    }
}
