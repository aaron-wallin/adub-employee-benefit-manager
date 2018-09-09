using EBM.Data;
using EBM.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBM.Api.GraphTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeType(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            Field(_ => _.EmployeeId);
            Field(_ => _.FirstName);
            Field(_ => _.LastName);
            Field<IntGraphType>("dependentCount", 
                resolve: _ => _.Source.Dependents.Count);
            Field<ListGraphType<DependentType>>("dependents",
                resolve: _ => this._employeeRepository.Get(_.Source.EmployeeId).Dependents);
        }
    }
}
