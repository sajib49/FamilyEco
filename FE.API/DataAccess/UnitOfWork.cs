using FE.API.Models;
using FE.API.Repositories;
using System;

namespace FE.API.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private FamilyEcoDbContext _context = new FamilyEcoDbContext();
        public IGenericRepository<Person> personRepository;

        public IGenericRepository<Person> PersonRepository
        {
            get
            {

                if (this.personRepository == null)
                {
                    this.personRepository = new GenericRepository<Person>(_context);
                }
                return personRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}