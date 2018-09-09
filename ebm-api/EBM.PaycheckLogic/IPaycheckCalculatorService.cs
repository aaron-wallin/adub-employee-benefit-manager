using EBM.Entities;

namespace EBM.PaycheckLogic
{
    public interface IPaycheckCalculatorService
    {
        void Calculate(Employee employee);
    }
}