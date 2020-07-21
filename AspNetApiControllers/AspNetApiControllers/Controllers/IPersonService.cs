using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetApiControllers.Controllers
{
    public interface IPersonService
    {
        Person GetPersonById(int id);
        List<Person> GetAllPeople();
        void AddPerson(Person person);
        Person UpdatePerson(Person person);
        Person DeletePersonById(int id);
    }
}