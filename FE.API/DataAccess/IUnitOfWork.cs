using FE.API.Models;
using System;
using FE.API.Repositories;

namespace FE.API.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Person> PersonRepository { get; }
        void Save();
    }
}
