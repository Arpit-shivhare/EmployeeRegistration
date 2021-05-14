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

        #region delete
        public void DeleteEmployee(Employee model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            _repository.Delete(model);
        }
        #endregion

        #region get
        public IList<Employee> GetAllEmployees(string EmployeeName)
        {
            var query = _repository.Table;
                       
            if (!string.IsNullOrEmpty(EmployeeName))
            {
                query = query.Where(e => e.Name.Contains(EmployeeName));
            }
            return query.OrderBy(e => e.Name).ToList();
        }
        #endregion


        #region insert
        public void InsertEmployee(Employee model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            _repository.Insert(model);
        }
        #endregion

        #region update
        public void UpdateEmployee(Employee model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

           _repository.Update(model);
        }

        #endregion

        #endregion
    }
}
