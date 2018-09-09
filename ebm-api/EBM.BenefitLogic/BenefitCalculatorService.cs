using EBM.BenefitLogic.BenefitPolicies;
using EBM.Entities;
using EBM.Entities.Base;

namespace EBM.BenefitLogic
{
    public class BenefitCalculatorService : IBenefitCalculatorService
    {
        private IBenefitDiscountPolicy _benefitDiscountPolicy;

        public BenefitCalculatorService(IBenefitDiscountPolicy benefitDiscountPolicy)
        {
            _benefitDiscountPolicy = benefitDiscountPolicy;
        }

        public BenefitInfo Calculate(Employee employee)
        {
            var benefitsSummary = new BenefitInfo();

            CalculateForIndividual(employee, benefitsSummary);

            foreach (var d in employee.Dependents)
            {
                CalculateForIndividual(d, benefitsSummary);
            }

            return benefitsSummary;
        }

        private void CalculateForIndividual(IBenefitPerson person, BenefitInfo benefitsSummary)
        {
            _benefitDiscountPolicy.CalculateDiscount(person);

            benefitsSummary.BaseAnnualCost += person.Benefits.BaseAnnualCost;
            benefitsSummary.DiscountedAnnualCost += person.Benefits.DiscountedAnnualCost;
            benefitsSummary.DiscountApplied = benefitsSummary.DiscountApplied || person.Benefits.DiscountApplied;
        }
    }
}
