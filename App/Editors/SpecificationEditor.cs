//-----------------------------------------------------------------------
// <copyright file="SpecificationEditor.cs" company="Sergey Teplyashin">
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
// <date>14.11.2014</date>
// <time>13:52</time>
// <summary>Defines the SpecificationEditor class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Editors
{
    using System;
    using System.Linq;
    using NHibernate.Linq;
    using WorkProject.Data.Entities;
    using WorkProject.Editors.Base;
    using WorkProject.Utils;

    public partial class SpecificationEditor : ObjectEditor<Specification>
    {
        public SpecificationEditor()
        {
            InitializeComponent();
            ActiveControl = textName;
            numericPrice.DataBindings.Add("Enabled", checkPrice, "Checked");
            numericProfit.DataBindings.Add("Enabled", checkProfit, "Checked");
            numericProfitPercent.DataBindings.Add("Enabled", checkProfitPercent, "Checked");
            comboTaxValue.DataBindings.Add("Enabled", checkTaxValue, "Checked");
        }
        
        calculation_method Method
        {
            get { return (calculation_method)comboCalcMethod.SelectedIndex; }
        }
        
        short TaxValue
        {
            get { return (new short[] { 0, 10, 18 })[comboTaxValue.SelectedIndex]; }
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            Current.Product = MasterEntity as Product;
            comboCalcMethod.SelectedIndex = 0;
            comboTaxValue.SelectedIndex = 2;
            numericProfitPercent.Value = 20;
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textName.Text = Current.Name;
            dateSpec.Value = Current.DateApproval;
            textComment.Text = Current.CommentText;
            textCost.Text = Current.Cost.ToString("0.00");
            numericProfit.Value = Current.Profit;
            numericProfitPercent.Value = Current.ProfitPercent;
            numericPrice.Value = Current.Price;
            comboCalcMethod.SelectedIndex = (int)Current.CalcPriceMethod;
            checkDefault.Checked = Current.IsDefault;
            textTaxSumma.Text = Current.TaxSumma.ToString("0.00");
            textSumma.Text = Current.Summa.ToString("0.00");
            comboTaxValue.SelectedIndex = Current.TaxValue == 0 ? 0 : (Current.TaxValue == 10 ? 1 : 2);
            
            var list = from i in Session.Query<ItemSpecification>()
                where i.Specification == Current
                group i by i.Article.Id
                into g
                    select new {
                        Article = g.Key,
                        Summa = g.Sum(_ => _.Summa)
                    };
            
            var articles = from i in Session.Query<Article>()
                orderby i.Code
                select i;
            
            foreach (var article in articles)
            {
                int row = gridCalc.Rows.Add();
                gridCalc.Rows[row].Cells[0].Value = article.Code;
                gridCalc.Rows[row].Cells[1].Value = article.Name;
                switch (article.Calculation)
                {
                    case article_calculation.other:
                    case article_calculation.content:
                        var c = list.FirstOrDefault(x => x.Article == article.Id);
                        if (c != null)
                        {
                            gridCalc.Rows[row].Cells[2].Value = c.Summa.ToString("0.00");
                        }
                        else
                        {
                            gridCalc.Rows.RemoveAt(row);
                        }
                        
                        break;
                    case article_calculation.cost:
                        gridCalc.Rows[row].Cells[2].Value = Current.Cost.ToString("0.00");
                        break;
                    case article_calculation.price:
                        gridCalc.Rows[row].Cells[2].Value = Current.Price;
                        break;
                    case article_calculation.profit:
                        gridCalc.Rows[row].Cells[2].Value = Current.Profit;
                        break;
                    case article_calculation.summa:
                        gridCalc.Rows[row].Cells[2].Value = Current.Summa.ToString("0.00");
                        break;
                    case article_calculation.tax:
                        gridCalc.Rows[row].Cells[2].Value = Current.TaxSumma.ToString("0.00");
                        break;
                }
            }
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Name = textName.Text;
            Current.DateApproval = dateSpec.Value;
            Current.CommentText = textComment.Text.NullIfEmpty();
            Current.Profit = numericProfit.Value;
            Current.ProfitPercent = numericProfitPercent.Value;
            Current.Price = numericPrice.Value;
            Current.TaxValue = TaxValue;
            Current.CalcPriceMethod = (calculation_method)comboCalcMethod.SelectedIndex;
            Current.TaxSumma = textTaxSumma.Text.ToDecimal();
            Current.Summa = textSumma.Text.ToDecimal();
            Current.IsDefault |= checkDefault.Checked;
        }
        
        void NumericCostValueChanged(object sender, EventArgs e)
        {
            if (!Locked)
            {
                switch (Method)
                {
                    case calculation_method.profit:
                        numericProfit.Value = Math.Round(Current.Cost * numericProfitPercent.Value / 100, 2);
                        break;
                    case calculation_method.price:
                        numericProfit.Value = numericPrice.Value - Current.Cost;
                        break;
                    default:
                        throw new Exception("Invalid value for calc_method");
                }
            }
        }
        
        void NumericProfitValueChanged(object sender, EventArgs e)
        {
            if (!Locked)
            {
                switch (Method)
                {
                    case calculation_method.profit:
                        numericPrice.Value = Current.Cost + numericProfit.Value;
                        break;
                    case calculation_method.price:
                        numericProfitPercent.Value = Math.Round((numericProfit.Value / Current.Cost) * 100, 2);
                        break;
                    default:
                        throw new Exception("Invalid value for calc_method");
                }
            }
        }
        
        void NumericProfitPercentValueChanged(object sender, EventArgs e)
        {
            if (!Locked)
            {
                numericProfit.Value = Math.Round(Current.Cost * numericProfitPercent.Value / 100, 2);
            }
        }
        
        void ComboCalcMethodSelectedIndexChanged(object sender, EventArgs e)
        {
            checkPrice.Enabled = Method == calculation_method.price;
            checkProfitPercent.Enabled = Method == calculation_method.profit;
            if (checkPrice.Checked && !checkPrice.Enabled)
            {
                checkPrice.Checked = false;
            }
            
            if (checkProfitPercent.Checked && !checkProfitPercent.Enabled)
            {
                checkProfitPercent.Checked = false;
            }
        }
        
        void UpdateFinishPrice()
        {
            decimal taxSumma = Math.Round(numericPrice.Value * TaxValue / 100, 2);
            decimal summa = numericPrice.Value + taxSumma;
            textTaxSumma.Text = taxSumma.ToString("0.00");
            textSumma.Text = summa.ToString("0.00");
        }
        
        void NumericPriceValueChanged(object sender, EventArgs e)
        {
            if (!Locked)
            {
                numericProfit.Value = numericPrice.Value - Current.Cost;
                UpdateFinishPrice();
            }
        }
        
        void ComboTaxValueSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locked)
            {
                UpdateFinishPrice();
            }
        }
    }
}
