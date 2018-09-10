using EBM.Entities;
using GraphQL.Types;

namespace EBM.Api.GraphTypes
{
    public class PaycheckType : ObjectGraphType<PayCheck>
    {
        public PaycheckType()
        {
            Field(_ => _.Deductions);
            Field(_ => _.GrossAmount);
            Field(_ => _.NetAmount);
        }
    }
}
