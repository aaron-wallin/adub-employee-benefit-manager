using EBM.Entities;
using System;
using System.Collections.Generic;

namespace EBM.Data
{
    public interface IEmployeeRepository
    {
        Employee Save(Employee employee);
        Employee Get(string employeeId);
        IEnumerable<Employee> GetAll();
        void Delete(string employeeId);
    }
}
