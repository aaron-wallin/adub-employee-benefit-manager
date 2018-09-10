using EBM.Data;
using EBM.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
