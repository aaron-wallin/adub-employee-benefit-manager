using EBM.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.BenefitLogic.BenefitPolicies
{
    public interface IBenefitDiscountPolicy
    {
        void CalculateDiscount(IBenefitPerson benefitEligiblePerson);
    }
}
