using EBM.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.BenefitLogic.BenefitPolicies
{
    public class NameDiscountPolicy : IBenefitDiscountPolicy
    {
        public void CalculateDiscount(IBenefitPerson person)
        {
            if(QualifiesForDiscount(person as IBenefitPerson))
            {
                ApplyDiscount(person as IBenefitPerson);
            }
        }

        private bool QualifiesForDiscount(IBenefitPerson person)
        {
            bool result = false;
            
            if(!string.IsNullOrWhiteSpace(person.FirstName) && person.FirstName.ToLower()[0] == 'a')
            {
                result = true;
            }

            return result;
        }

        private void ApplyDiscount(IBenefitPerson benefitEligiblePerson)
        {
            benefitEligiblePerson.Benefits.DiscountedAnnualCost = benefitEligiblePerson.Benefits.BaseAnnualCost * .9M;
            benefitEligiblePerson.Benefits.DiscountApplied = true;
        }
    }
}
