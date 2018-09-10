using System;
using System.Collections.Generic;

namespace EBM.Entities.Factories
{
    public class EmployeeFactory
    {
        private decimal _annualBenefitCost = 1000;

        public Employee CreateEmployee(decimal annualSalary, int payPeriodsPerYear)
        {
            return new Employee()
            {
                EmployeeId = Guid.NewGuid().ToString(),
                FirstName = "",
                LastName = "",
                Salary = new SalaryInfo()
                {
                    AnnualSalary = annualSalary,
                    PayPeriodsPerYear = payPeriodsPerYear
                },
                Benefits = new BenefitInfo()
                {
                    BaseAnnualCost = _annualBenefitCost,
                    DiscountedAnnualCost = _annualBenefitCost,
                    DiscountApplied = false
                },
                BenefitSummary = new BenefitInfo(),
                Dependents = new List<Dependent>(),
                PayCheck = new PayCheck()
            };
        }
    }
}
