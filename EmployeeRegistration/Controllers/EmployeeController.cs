using _Core.Domain;
using _Services;
using EmployeeRegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Controllers
{
    public class EmployeeController : Controller
    {
        #region fields
        private readonly IEmployeeService _employeeService;
        #endregion


        #region ctor
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion


        #region methods
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new Employee();

                data.Name = model.Name;
                data.Email = model.Email;
                data.MobileNo = model.MobileNo;
                data.Gender = (int)model.Gender;
                data.Address = model.Address;

                _employeeService.InsertEmployee(data);
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult List(string employeeName = null)
        {
            var model = new List<EmployeeModel>();

            var data = _employeeService.GetAllEmployees();

            if (!(string.IsNullOrEmpty(employeeName)))
            {
                var employee = data.Where(e => e.Name.Contains(employeeName)).ToList();

                if(employee.Count > 0)
                {
                    foreach(var item in employee)
                    {

                    }
                }
            }
            else
            {
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var employeeData = new EmployeeModel
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Email = item.Email,
                            MobileNo = item.MobileNo,
                            Gender = (EmployeeRegistration.ViewModels.GenderType)item.Gender,
                            Address = item.Address
                        };

                        model.Add(employeeData);
                    }
                }

            }


            return View(model);
        }

        #endregion
    }
}
