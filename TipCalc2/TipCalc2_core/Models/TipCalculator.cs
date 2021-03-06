﻿using TipCalc2_core.Interfaces;

namespace TipCalc2_core.Models
{
    public class TipCalculator : ITipCalculator
    {
        private double total;
        private double tip;
        private double tipPercent;
        private double grandTotal;

        public double Total {
            get { return total; }
            set { total = value; }
        }

        public double Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public double TipPercent
        {
            get { return tipPercent; }
            set { tipPercent = value; }
        }

        public double GrandTotal
        {
            get { return grandTotal; }
        }

        public void CalcTip()
        {
            if (tipPercent > 0)
            {
                tip = total * (tipPercent / 100);                
            }
            else
            {
                tip = 0;
            }
            UpdateGrandTotal();
        }

        public void CalcTipPercentage()
        {
            if (total > 0)
            {
                tipPercent = (tip / total) * 100;
            }
            else
            {
                tipPercent = 0;
            }

            UpdateGrandTotal();
        }
        
        private void UpdateGrandTotal()
        {
            grandTotal = total + tip;
        }
    }
}
