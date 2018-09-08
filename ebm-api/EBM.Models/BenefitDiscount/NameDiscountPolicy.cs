using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Models.BenefitDiscount
{
    public class NameDiscountPolicy : IBenefitDiscountPolicy
    {
        public void CalculateDiscount(IBenefitEligiblePerson person)
        {
            if(QualifiesForDiscount(person as IBenefitEligiblePerson))
            {
                ApplyDiscount(person as IBenefitEligiblePerson);
            }
        }

        private bool QualifiesForDiscount(IBenefitEligiblePerson person)
        {
            bool result = false;
            
            if(!string.IsNullOrWhiteSpace(person.FirstName) && person.FirstName.ToLower()[0] == 'a')
            {
                result = true;
            }

            return result;
        }

        private void ApplyDiscount(IBenefitEligiblePerson benefitEligiblePerson)
        {
            benefitEligiblePerson.Benefits.DiscountedAnnualCost = Convert.ToInt32(benefitEligiblePerson.Benefits.BaseAnnualCost * .9);
            benefitEligiblePerson.Benefits.DiscountApplied = true;
        }
    }
}
