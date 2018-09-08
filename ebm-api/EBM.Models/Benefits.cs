using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Models
{
    public class Benefits
    {
        public int BaseAnnualCost { get; set; }
        public decimal DiscountedAnnualCost { get; set; }
        public bool DiscountApplied { get; set; }
        public decimal PerPayPeriodCost { get { return Math.Round(DiscountedAnnualCost / 26, 2); } }

        public Benefits()
        {

        }

        public Benefits(int baseAnnualCost)
        {
            BaseAnnualCost = baseAnnualCost;
            DiscountedAnnualCost = BaseAnnualCost;
            DiscountApplied = false;
        }
    }
}
