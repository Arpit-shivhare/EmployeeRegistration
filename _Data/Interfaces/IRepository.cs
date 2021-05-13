using _Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Data.Interfaces
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }



    }
}
