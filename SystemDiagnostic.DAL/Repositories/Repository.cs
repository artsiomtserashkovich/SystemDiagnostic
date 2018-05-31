using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;

namespace SystemDiagnostic.DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDataBaseContext _applicationDataBaseContext;

        protected DbSet<TEntity> _DbSet;

        protected Repository(ApplicationDataBaseContext applicationDataBaseContext)
        {
            _applicationDataBaseContext = applicationDataBaseContext;
            _DbSet = _applicationDataBaseContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return _DbSet.Add(entity).Entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _DbSet.AddRange(entities);   
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public TEntity Get(string id)
        {
            return _DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _DbSet;
        }

        public TEntity Remove(TEntity entity)
        {
            return _DbSet.Remove(entity).Entity;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public TEntity SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.SingleOrDefault(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            return _DbSet.Update(entity).Entity;
        }
    }
}
