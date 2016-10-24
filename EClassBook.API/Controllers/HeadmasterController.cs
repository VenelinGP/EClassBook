// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EClassBook.API.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Data.Context;
    using Model.Entities;
    using System.Linq;

    [Route("api/headmaster")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = -1)]
    public class HeadmasterController : Controller
    {
        private EBookContext _context;


        public HeadmasterController(EBookContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public Headmaster Get()
        {
            var result = _context.Headmasters.ToList();
            var headmaster = result[0];
            var address = _context.Address.ToList()[0];
            var role = _context.Roles.ToList()[0];
            return headmaster;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
