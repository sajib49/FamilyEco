using FE.API.Models;
using System.Web.Http;
using FE.API.DataAccess;
using FE.API.Repositories;
using System.Web.Http.Description;

namespace FE.API.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonController : ApiController
    {
        private UnitOfWork<FamilyEcoDbContext> unitOfWork = new UnitOfWork<FamilyEcoDbContext>();
        private IPersonRepository personRepository;

        public PersonController()
        {
            personRepository = new PersonRepository(unitOfWork);
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            var persons = personRepository.Find(x => x.Id == id);
            return Ok(persons);
        }


        [HttpPost]
        [ResponseType(typeof(Person))]
        public IHttpActionResult AddPerson(Person aPerson)
        {
            if (!ModelState.IsValid)
            {                
                return BadRequest(ModelState);
            }

            try
            {
                unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    personRepository.Insert(aPerson);
                    unitOfWork.Save();
                    unitOfWork.Commit();
                }
            }
            catch
            {                
                unitOfWork.Rollback();
            }

            return Created("", aPerson);
        }
    }
}
