using System.Collections.Generic;

namespace EBM.Entities
{
    public class PayCheck
    {
        public decimal GrossAmount { get; set; }
        public Dictionary<string, decimal> Deductions { get; set; } = new Dictionary<string, decimal>();
        public decimal NetAmount { get; set; }
    }
}
