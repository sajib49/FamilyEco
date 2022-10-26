using FE.API.DataAccess;
using FE.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FE.API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly FamilyEcoDbContext _context;
        public PersonRepository(FamilyEcoDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }
        public Person GetPersonById(int personId)
        {
            return _context.Persons.Find(personId);
        }
        public void AddPerson(Person personEntity)
        {
            if (personEntity != null)
            {
                _context.Persons.Add(personEntity);
            }
        }
        public void UpdatePerson(Person personEntity)
        {
            if (personEntity != null)
            {
                _context.Entry(personEntity).State = EntityState.Modified;
            }
        }
        public void DeletePerson(int personId)
        {
            Person personEntity = _context.Persons.Find(personId);
            _context.Persons.Remove(personEntity);
        }
        public void Save()
        {
            _context.SaveChanges();
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
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}