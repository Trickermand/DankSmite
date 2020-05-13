using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DankSmite.Controllers
{
    [Route("")]
    [Route("[Controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult MyIndex()
        {

            return View(new MyIndexModel());
        }
    }
}