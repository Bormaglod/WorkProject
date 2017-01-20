//-----------------------------------------------------------------------
// <copyright file="OperationEditor.cs" company="Sergey Teplyashin">
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
// <date>07.11.2014</date>
// <time>9:37</time>
// <summary>Defines the OperationEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using System.Windows.Forms;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;

    public partial class OperationEditor : ObjectEditor<Operation>
    {
        bool lockCalc;
        bool lockCheck;
        ComponentFactory.Krypton.Toolkit.KryptonCheckBox[] checks;
        int currentCheck;
        
        public OperationEditor()
        {
            InitializeComponent();
            ActiveControl = textName;
            checks = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox[3] { checkSalary, checkTimeRate, checkPrice };
            CurrentCheck = 2;
        }
        
        int CurrentCheck
        {
            get
            {
                return currentCheck;
            }
            
            set
            {
                currentCheck = value;
                lockCheck = true;
                try
                {
                    for (int i = 0; i < 3; i++)
                    {
                        checks[i].Checked = i == currentCheck;
                    }
                    
                    UpdateControlValues();
                }
                finally
                {
                    lockCheck = false;
                }
            }
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            selectGroup.LoadGroups<Operation>(Viewer == null ? null : Viewer.CurrentGroup as GroupItem);
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            lockCalc = true;
            try
            {
                textName.Text = Current.Name;
                selectGroup.LoadGroups<Operation>(Current.Group);
                numericSalary.Value = Current.Salary;
                numericTimeRate.Value = Current.TimeRate;
                numericPrice.Value = Current.Price;
            }
            finally
            {
                lockCalc = false;
            }
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Name = textName.Text;
            Current.Group = selectGroup.GetSelectedEntity<GroupItem>();
            Current.Salary = numericSalary.Value;
            Current.TimeRate = Convert.ToInt32(numericTimeRate.Value);
            Current.Price = numericPrice.Value;
        }
        
        decimal CalcTimeRate()
        {
            return numericPrice.Value == 0 ? 0 : numericSalary.Value / numericPrice.Value;
        }
        
        decimal CalcPrice()
        {
            return numericTimeRate.Value == 0 ? 0 : numericSalary.Value / numericTimeRate.Value;
        }
        
        decimal CalcSalary()
        {
            return numericTimeRate.Value * numericPrice.Value;
        }
        
        void CalculateValues()
        {
            if (lockCalc)
            {
                return;
            }
            
            switch (CurrentCheck)
            {
                case 0:
                    numericSalary.Value = CalcSalary();
                    break;
                case 1:
                    numericTimeRate.Value = CalcTimeRate();
                    break;
                case 2:
                    numericPrice.Value = CalcPrice();
                    break;
            }
        }
        
        void UpdateControlValues()
        {
            numericPrice.Enabled = CurrentCheck != 2;
            numericTimeRate.Enabled = CurrentCheck != 1;
            numericSalary.Enabled = CurrentCheck != 0;
        }
        
        void TrackSelectCalcValueScroll(object sender, EventArgs e)
        {
            UpdateControlValues();
        }
        
        void OperationValuesChanged(object sender, EventArgs e)
        {
            CalculateValues();
        }
        
        void SelectCalcValue(object sender, EventArgs e)
        {
            if (lockCheck)
            {
                return;
            }
            
            CurrentCheck = Convert.ToInt32((sender as Control).Tag);
        }
    }
}
