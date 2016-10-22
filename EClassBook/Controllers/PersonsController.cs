// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EClassBook.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Context;
    using System.Linq;

    [Route("api/persons")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = -1)]
    public class PersonsController : Controller
    {
        private EBookContext _context;

        public PersonsController(EBookContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return _context.Persons.ToList();
        }
    }
}
