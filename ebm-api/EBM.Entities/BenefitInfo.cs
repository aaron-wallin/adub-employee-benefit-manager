using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Entities
{
    public class BenefitInfo
    {
        public decimal BaseAnnualCost { get; set; }
        public decimal DiscountedAnnualCost { get; set; }
        public bool DiscountApplied { get; set; }
    }
}
