using FE.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FE.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        public FamilyEcoDbContext Context { get; set; }
        private IDbSet<T> _entities;
        public GenericRepository(IUnitOfWork<FamilyEcoDbContext> unitOfWork)
            : this(unitOfWork.Context)
        {
        }

        public GenericRepository(FamilyEcoDbContext context)
        {
            Context = context;
        }

        public virtual IQueryable<T> Table
        {
            get { return Entities; }
        }

        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }

        public virtual IEnumerable<T> FindAll()
        {
            return Entities.ToList();
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate).FirstOrDefault();
        }

        public virtual void Insert(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            Entities.Remove(entity);
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;
            Context.Set<T>().AddRange(entities);
            Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            Entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            Entities.Remove(entity);
        }

        public virtual void SetEntryModified(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var entityToDelete = Entities.Find(id);
            Delete(entityToDelete);
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }
}