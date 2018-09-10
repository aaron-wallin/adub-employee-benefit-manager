namespace EBM.Entities.Factories
{
    public class DependentFactory
    {
        private decimal _annualBenefitCost = 500;

        public Dependent CreateDependent(string firstName, string lastName)
        {
            return new Dependent()
            {
                FirstName = firstName,
                LastName = lastName,
                Benefits = new BenefitInfo()
                {
                    BaseAnnualCost = _annualBenefitCost,
                    DiscountedAnnualCost = _annualBenefitCost,
                    DiscountApplied = false
                }
            };
        }
    }
}
