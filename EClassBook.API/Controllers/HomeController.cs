// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EClassBook.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var rand = new Random();
            await Task.Delay(rand.Next(0, 50)); // Emulate tiny latency...
            var result = new
            {
                numbers = Enumerable.Range(1, 10)
                                            .Select(i => i * rand.NextDouble())
                                            .ToArray()

            };
            return new JsonResult(result);
            //var jsonString = "{\"id\":1,\"name\":\"a small object\" }";
            //return new JsonResult(jsonString);
        }
    }
}
