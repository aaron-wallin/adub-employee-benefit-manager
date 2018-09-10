using EBM.Entities.Base;

namespace EBM.BenefitLogic.BenefitPolicies
{
    public interface IBenefitDiscountPolicy
    {
        void CalculateDiscount(IBenefitPerson benefitEligiblePerson);
    }
}
