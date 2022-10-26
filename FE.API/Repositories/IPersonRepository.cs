using FE.API.Models;
using System;
using System.Collections.Generic;

namespace FE.API.Repositories
{
    public interface IPersonRepository : IDisposable
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int bookId);
        void AddPerson(Person bookEntity);
        void UpdatePerson(Person bookEntity);
        void DeletePerson(int personId);
        void Save();
    }
}
