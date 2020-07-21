using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetApiControllers.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class PersonController : ControllerBase
    {

        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public List<Person> Get()
        {
            return _personService.GetAllPeople();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _personService.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            
            var personToDelete = _personService.DeletePersonById(id);

            if (personToDelete == null)
            {
                return BadRequest();
            }


            return Ok();
        }

        [HttpPost]
        public ActionResult<Person> Add(Person person)
        {
            _personService.AddPerson(person);
            return person;
        }

        [HttpPut]
        public ActionResult<Person> Update(Person person)
        {

            var personToUpdate = _personService.UpdatePerson(person);
            if (personToUpdate == null)
            {
                return BadRequest();
            }

            return personToUpdate;
        }
    }
}
