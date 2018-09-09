using EBM.Entities;

namespace EBM.BenefitLogic
{
    public interface IBenefitCalculatorService
    {
        BenefitInfo Calculate(Employee employee);
    }
}