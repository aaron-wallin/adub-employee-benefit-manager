using EBM.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBM.Api.GraphTypes
{
    public class DependentInputType : InputObjectGraphType<Dependent>
    {
        public DependentInputType()
        {
            Name = "DependentInput";         
            Field(_ => _.FirstName);
            Field(_ => _.LastName);
        }
    }
}
