using EBM.Models.BenefitDiscount;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Models
{
    public class BenefitCalculatorService
    {
        private IBenefitDiscountPolicy _benefitDiscountPolicy;

        public BenefitCalculatorService(IBenefitDiscountPolicy benefitDiscountPolicy)
        {
            _benefitDiscountPolicy = benefitDiscountPolicy;
        }

        public Benefits Calculate(Employee employee)
        {
            var benefitsSummary = new Benefits();

            CalculateForIndividual(employee, benefitsSummary);

            foreach (var d in employee.Dependents)
            {
                CalculateForIndividual(d, benefitsSummary);
            }

            return benefitsSummary;
        }

        private void CalculateForIndividual(IBenefitEligiblePerson person, Benefits benefitsSummary)
        {
            _benefitDiscountPolicy.CalculateDiscount(person);

            benefitsSummary.BaseAnnualCost += person.Benefits.BaseAnnualCost;
            benefitsSummary.DiscountedAnnualCost += person.Benefits.DiscountedAnnualCost;
            benefitsSummary.DiscountApplied = benefitsSummary.DiscountApplied || person.Benefits.DiscountApplied;
        }
    }
}
