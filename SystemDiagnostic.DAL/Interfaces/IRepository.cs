using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
