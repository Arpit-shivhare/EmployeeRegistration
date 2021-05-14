using _Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace _Services
{
    
    public interface IEmployeeService
    {
        void DeleteEmployee(Employee model);
        void InsertEmployee(Employee model);
        void UpdateEmployee(Employee model);
        IList<Employee> GetAllEmployees(string EmployeeName = null);

    }
}
