using EBM.Entities;
using GraphQL.Types;

namespace EBM.Api.GraphTypes
{
    public class EmployeeInputType : InputObjectGraphType<Employee>
    {
        public EmployeeInputType()
        {
            Name = "EmployeeInput";
            Field(_ => _.EmployeeId);
            Field(_ => _.FirstName);
            Field(_ => _.LastName);
            Field<ListGraphType<DependentInputType>>("dependents");
        }
    }
}
