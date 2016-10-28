using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EClassBook.API.Controllers
{
    public class PartialController : Controller
    {
        public IActionResult Message() => PartialView();

        public IActionResult Numbers() => PartialView();
    }
}
