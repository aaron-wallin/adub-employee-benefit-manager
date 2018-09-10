using EBM.Api.GraphTypes;
using EBM.Data;
using EBM.Entities;
using EBM.Entities.Factories;
using EBM.PaycheckLogic;
using GraphQL.Types;
using System;

namespace EBM.Api.GraphRoot
{
    public class GraphDataMutation : ObjectGraphType
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPaycheckCalculatorService _paycheckCalculatorService;
        private readonly EmployeeFactory _employeeFactory;
        private readonly DependentFactory _dependentFactory;

        public GraphDataMutation(IEmployeeRepository employeeRepository, 
                                 IPaycheckCalculatorService paycheckCalculatorService,
                                 EmployeeFactory employeeFactory,
                                 DependentFactory dependentFactory)
        {
            _employeeRepository = employeeRepository;
            _paycheckCalculatorService = paycheckCalculatorService;
            _employeeFactory = employeeFactory;
            _dependentFactory = dependentFactory;

            Name = "Mutation";

            Field<EmployeeType>(
                "saveEmployee",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" }
                ),
                resolve: context =>
                {
                    var data = context.GetArgument<Employee>("employee");
                    return ProcessSave(data);
                }
            );
        }

        private Employee ProcessSave(Employee employeeData)
        {
            var empObj = _employeeFactory.CreateEmployee(52000, 26);
            empObj.FirstName = employeeData.FirstName;
            empObj.LastName = employeeData.LastName;
            empObj.EmployeeId = string.IsNullOrWhiteSpace(employeeData.EmployeeId) ?
                                 Guid.NewGuid().ToString() :
                                 employeeData.EmployeeId;

            foreach (var d in employeeData.Dependents)
            {
                empObj.Dependents.Add(_dependentFactory.CreateDependent(d.FirstName, d.LastName));
            }

            _paycheckCalculatorService.Calculate(empObj);

            return _employeeRepository.Save(empObj);
        }
    }
}
