using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.ViewModels
{
    public class EmployeeSearchModel
    {
        public EmployeeSearchModel()
        {
            Employees = new List<EmployeeModel>();

        }
        public string EmployeeName { get; set; }
        public List<EmployeeModel> Employees = new List<EmployeeModel>();
            
    }
}
