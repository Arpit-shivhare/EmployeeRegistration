using _Core.Domain;
using _Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _Services
{
    public class EmployeeService : IEmployeeService
    {
        #region fields

        private readonly IRepository<Employee> _repository;

        #endregion

        #region ctor
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        #endregion



        #region methods
        public void DeleteEmployee(Employee model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            _repository.Delete(model);
        }

        public IList<Employee> GetAllEmployees()
        {
            var query = from emp in _repository.Table
                        orderby emp.Name
                        select emp;
            var EmpList = query.ToList();
            return EmpList;
        }

        public void InsertEmployee(Employee model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            _repository.Insert(model);
        }

        public IList<Employee> Search(string employeeName)
        {
            if (string.IsNullOrEmpty(employeeName))
            {
                var query = from emp in _repository.Table
                            orderby emp.Name
                            select emp;
                var EmpList = query.ToList();
                return EmpList;
            }

            return _repository.Table.Where(e => e.Name.Contains(employeeName)).ToList();
        }

        public void UpdateEmployee(Employee model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

           _repository.Update(model);
        }

        #endregion
    }
}
