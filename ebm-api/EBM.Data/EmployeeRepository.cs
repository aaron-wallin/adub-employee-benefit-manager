using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using EBM.Entities;
using EBM.Entities.Factories;

namespace EBM.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        // just simulating actual data storage for now
        private static readonly ConcurrentDictionary<string, Employee> employeeData = new ConcurrentDictionary<string, Employee>();

        public EmployeeRepository()
        {
            var ef = new EmployeeFactory();
            var df = new DependentFactory();

            var emp = ef.CreateEmployee(52000, 26);            
            emp.FirstName = "Aaron";
            emp.LastName = "Wallin";
            emp.Dependents.Add(df.CreateDependent("Alex", "Wallin"));
            emp.Dependents.Add(df.CreateDependent("Cat", "Wallin"));
            emp.Dependents.Add(df.CreateDependent("Heidi", "Wallin"));

            Save(emp);            
        }

        public Employee Get(string employeeId)
        {
            Employee e = null;
            employeeData.TryGetValue(employeeId, out e);
            return e;
        }

        public void Save(Employee employee)
        {
            employeeData.AddOrUpdate(employee.EmployeeId, employee, (k, v) => employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            var listOfEmp = new List<Employee>();
            
            foreach(KeyValuePair<string, Employee> e in employeeData)
            {
                listOfEmp.Add(e.Value);
            }

            return listOfEmp;
        }

        public void Delete(string employeeId)
        {
            Employee e = null;
            employeeData.TryRemove(employeeId, out e);
        }
    }
}
