using FE.API.DataAccess;
using FE.API.Models;

namespace FE.API.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(IUnitOfWork<FamilyEcoDbContext> unitOfWork)
           : base(unitOfWork)
        {
        }

        //public PersonRepository(FamilyEcoDbContext context)
        //    : base(context)
        //{
        //}
    
    }
}