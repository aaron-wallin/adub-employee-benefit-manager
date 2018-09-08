using System;
using System.Collections.Generic;
using System.Text;

namespace EBM.Entities.Base
{
    public interface IBenefitPerson : IPerson
    {
        BenefitInfo Benefits { get; }
    }
}
