using EBM.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBM.Api.GraphTypes
{
    public class BenefitInfoType : ObjectGraphType<BenefitInfo>
    {
        public BenefitInfoType()
        {   
            Field(_ => _.BaseAnnualCost);
            Field(_ => _.DiscountApplied);
            Field(_ => _.DiscountedAnnualCost);
        }
    }
}
