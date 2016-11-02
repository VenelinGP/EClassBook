namespace EClassBook.API.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    using Microsoft.AspNetCore.Mvc;
    using Model;

    [Route("api/persons")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = -1)]
    public class PersonsController : Controller
    {
        private EBookContext context;

        public PersonsController(EBookContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public IEnumerable<User> GetPersons()
        {
            return context.User.ToArray();
        }
    }
}