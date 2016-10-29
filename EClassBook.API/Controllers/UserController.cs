﻿namespace EClassBook.API.Controllers
{
    using System.Linq;
    using Data;

    using Microsoft.AspNetCore.Mvc;
    using Model;

    [Route("api/[controller]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = -1)]
    public class UserController : Controller
    {
        private EBookContext context;
        //private IDbRepository<Headmaster> headmaster;

        public UserController(EBookContext context)
        {
            this.context = context;
        }

        // GET: api/values
        [HttpGet]
        public User Get()
        {
            var result = this.context.User.ToList();
            var user = result.FirstOrDefault();
            var address = this.context.Address.ToList()[0];
            var role = this.context.Roles.ToList()[0];
            return user;
            // return _context.user.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]string value)
        {
            return this.View();
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