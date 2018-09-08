using EBM.BenefitLogic;
using EBM.Entities;
using System;

namespace EBM.PaycheckLogic
{
    public class PaycheckCalculatorService
    {
        private readonly BenefitCalculatorService _benefitCalculatorService;

        public PaycheckCalculatorService(BenefitCalculatorService benefitCalculatorService)
        {
            this._benefitCalculatorService = benefitCalculatorService;
        }

        public void Calculate(Employee employee)
        {
            var benefitInfo = _benefitCalculatorService.Calculate(employee);

            employee.PayCheck.GrossAmount = Math.Round(employee.Salary.AnnualSalary / employee.Salary.PayPeriodsPerYear, 2);
            employee.PayCheck.Deductions.Add("Benefits", Math.Round(benefitInfo.DiscountedAnnualCost / employee.Salary.PayPeriodsPerYear, 2));
            employee.PayCheck.NetAmount = Math.Round(employee.PayCheck.GrossAmount - (benefitInfo.DiscountedAnnualCost / employee.Salary.PayPeriodsPerYear), 2);
        }
    }
}
