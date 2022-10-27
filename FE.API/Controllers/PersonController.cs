using FE.API.DataAccess;
using FE.API.Models;
using FE.API.Repositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace FE.API.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonController : ApiController
    {
        private IUnitOfWork unitOfWork;

        public PersonController()
        {
            //For the time being we're not going to use dependency injection. Later we will.
            unitOfWork = new UnitOfWork();            
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetPerson(int id)
        {
            var persons = unitOfWork.PersonRepository.GetById(id);
            return Ok(persons);
        }

        [HttpPost]
        public IHttpActionResult AddPerson(Person aPerson)
        {
            if (!ModelState.IsValid)
            {                
                return BadRequest(ModelState);
            }

            unitOfWork.PersonRepository.Insert(aPerson);
            unitOfWork.Save();

            return Created("", aPerson);
        }
    }
}
