using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Models
{
    public interface IBenefitEligiblePerson : IPerson
    {
        Benefits Benefits { get; }
    }
}
