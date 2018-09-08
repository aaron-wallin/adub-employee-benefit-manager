using System;
using System.Collections.Generic;

namespace EBM.Models
{
    public class Employee : IBenefitEligiblePerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Benefits Benefits { get; private set; }

        public List<Dependent> Dependents { get; private set; }

        public int AnnualSalary { get; set; }

        public Employee()
        {
            Dependents = new List<Dependent>();
            Benefits = new Benefits(1000);
            AnnualSalary = 52000;
        }

        public void AddDependent(Dependent dependent)
        {
            if(dependent == null) throw new ArgumentNullException(nameof(dependent));
            Dependents.Add(dependent);
        }
    }
}
