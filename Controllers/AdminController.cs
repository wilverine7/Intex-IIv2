using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mummies.Controllers
{
    public class AdminController : Controller
    {
        ////////////////////
        /////   USERS
        ////////////////////
        public IActionResult Users()
        {
            return View();
        }

        ////////////////////
        /////   CRUD
        ////////////////////
        public IActionResult Crud()
        {
            return View();
        }
    }
}

