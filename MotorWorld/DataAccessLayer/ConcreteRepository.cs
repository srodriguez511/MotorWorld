using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MotorWorld.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MotorWorld.DataAccessLayer
{
    public class ConcreteRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public ConcreteRepository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

    }
}