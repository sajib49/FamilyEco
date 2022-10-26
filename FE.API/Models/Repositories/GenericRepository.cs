using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FE.API.Models.Repositories
{
    public class GenericRepository<TEntity>  where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;
        private readonly FamilyEcoDbContext _dbContext = new FamilyEcoDbContext();

        public GenericRepository()
        {
            DbSet = _dbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> FindAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateSpecificColumn(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties)
        {
            _dbContext.Entry(entity).State = EntityState.Unchanged;
            if (updatedProperties.Any())
                foreach (var propertyName in updatedProperties)
                {
                    _dbContext.Entry(entity).Property(propertyName).IsModified = true;
                }
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            DbSet.RemoveRange(DbSet.Where(predicate));
        }

        public virtual void AddRange(IEnumerable<TEntity> listEntities)
        {
            DbSet.AddRange(listEntities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> listEntities)
        {
            DbSet.RemoveRange(listEntities);
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}