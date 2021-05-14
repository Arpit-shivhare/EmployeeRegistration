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

        #region index
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region create
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
        #endregion



        #region list
        public IActionResult List()
        {
            var model = new EmployeeSearchModel();

            var data = _employeeService.GetAllEmployees();

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

                    model.Employees.Add(employeeData);
                }
            }

           return View(model);
        }
        #endregion


        #region searchEmployee
        [HttpPost]
        public IActionResult List(EmployeeSearchModel model)
        {
            var data = _employeeService.GetAllEmployees(model.EmployeeName);

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

                    model.Employees.Add(employeeData);
                }
            }

            return View(model);
        }
        #endregion

        #endregion
    }
}
