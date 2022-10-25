using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FE.API.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void UpdateSpecificColumn(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void AddRange(IEnumerable<TEntity> listEntities);
        void RemoveRange(IEnumerable<TEntity> listEntities);
        void Save();
    }
}
