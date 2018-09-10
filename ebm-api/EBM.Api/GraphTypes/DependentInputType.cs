using EBM.Entities;
using GraphQL.Types;

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
