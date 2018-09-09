using EBM.Api.GraphTypes;
using EBM.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBM.Api.GraphRoot
{
    public class GraphDataQuery : ObjectGraphType
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GraphDataQuery(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;

            Field<EmployeeType>(
                "employee",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "employeeId" }),
                resolve: _ => _employeeRepository.Get(_.GetArgument<string>("employeeId"))
                );

            Field<ListGraphType<EmployeeType>>(
                "employees",
                resolve: _ => _employeeRepository.GetAll()
                );
        }
    }
}
