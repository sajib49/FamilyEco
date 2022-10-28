using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FE.API.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> predicate);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Delete(object id);
    }
}
