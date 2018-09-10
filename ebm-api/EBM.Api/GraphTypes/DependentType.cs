using EBM.Data;
using EBM.Entities;
using GraphQL.Types;

namespace EBM.Api.GraphTypes
{
    public class DependentType : ObjectGraphType<Dependent>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DependentType(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
                        
            Field(_ => _.FirstName);
            Field(_ => _.LastName);
            Field<BenefitInfoType>("benefitInfo", 
                resolve: _ => _.Source.Benefits);
        }
    }
}
