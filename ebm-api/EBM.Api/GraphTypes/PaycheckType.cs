using EBM.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
