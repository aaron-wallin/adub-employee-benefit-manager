using EBM.Entities.Base;
using System;
using System.Collections.Generic;

namespace EBM.Entities
{
    public class Employee : IBenefitPerson, IEmployee
    {
        public BenefitInfo Benefits { get; set; }

        public BenefitInfo BenefitSummary { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SalaryInfo Salary { get; set; }

        public PayCheck PayCheck { get; set; }

        public List<Dependent> Dependents { get; set; }

        public string EmployeeId { get; set; }
        
        //protected internal Employee()
        //{

        //}        
    }
}
