using System.Collections.Concurrent;
using System.Collections.Generic;
using EBM.Entities;

namespace EBM.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        // just simulating actual data storage for now
        private static readonly ConcurrentDictionary<string, Employee> employeeData = new ConcurrentDictionary<string, Employee>();

        public EmployeeRepository()
        {   
        }

        public Employee Get(string employeeId)
        {
            Employee e = null;
            employeeData.TryGetValue(employeeId, out e);
            return e;
        }

        public Employee Save(Employee employee)
        {
            employeeData.AddOrUpdate(employee.EmployeeId, employee, (k, v) => employee);
            return employee;
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
