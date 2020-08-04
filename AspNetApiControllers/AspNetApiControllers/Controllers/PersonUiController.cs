using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetApiControllers.Controllers
{
    public class PersonUiController : Controller
    {
        private IPersonService _personService;
        public PersonUiController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            var people = _personService.GetAllPeople();
            return View(people);
        }

        public IActionResult GetPerson(int id)
        {
            var person = _personService.GetPersonById(id);
            return View(person);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            _personService.AddPerson(person);
            return RedirectToAction("Index");
        }
    }
}
