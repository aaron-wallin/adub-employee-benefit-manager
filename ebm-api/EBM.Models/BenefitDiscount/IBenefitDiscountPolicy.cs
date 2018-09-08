using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Models.BenefitDiscount
{
    public interface IBenefitDiscountPolicy
    {
        void CalculateDiscount(IBenefitEligiblePerson benefitEligiblePerson);
    }
}
