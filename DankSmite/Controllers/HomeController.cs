using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DankSmite.Pages.Shared;
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

        [HttpPost]
        public IActionResult MyIndex(string newInput)
        {
            return View(new MyIndexModel());
        }

        [HttpGet]
        [Route("ds")]
        public IActionResult DSRemake()
        {
            return View(new DSRemakeModel());
        }
    }
}