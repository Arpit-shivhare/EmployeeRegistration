using _Core;
using _Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region fields
        private readonly AppDbContext _dbContext;
        private DbSet<T> _entities;
        #endregion


        #region ctor
        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion



        #region methods
        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);

                _dbContext.SaveChanges();
                _dbContext.Entry<T>(entity).Reload();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }


        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                _dbContext.Entry<T>(entity).Reload();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }


        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);

                _dbContext.SaveChanges();
                _dbContext.Entry<T>(entity).Reload();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }


        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<T>();
                return _entities;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }


        #endregion
    }
}
