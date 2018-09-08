using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Entities.Base
{
    public interface IEmployee
    {
        string EmployeeId { get; }
        SalaryInfo Salary { get; }
        PayCheck PayCheck { get; set; }
        List<Dependent> Dependents { get; }
    }
}
