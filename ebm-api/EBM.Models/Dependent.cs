using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Models
{
    public class Dependent : IBenefitEligiblePerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public Benefits Benefits { get; private set; }

        public Dependent()
        {
            Benefits = new Benefits(500);
        }
    }
}
