using System.Collections.Generic;

namespace EBM.Entities.Base
{
    public interface IEmployee
    {
        string EmployeeId { get; }
        SalaryInfo Salary { get; }
        PayCheck PayCheck { get; set; }
        List<Dependent> Dependents { get; }
        BenefitInfo BenefitSummary { get; }
    }
}
