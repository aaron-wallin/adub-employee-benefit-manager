using EBM.Entities;
using GraphQL.Types;

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
