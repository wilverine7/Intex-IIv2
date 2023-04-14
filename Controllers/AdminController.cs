using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mummies.Data;
using Mummies.Models;
using Mummies.Models.Repo;
using Mummies.Models.Users;
using Mummies.Models.ViewModels;

namespace Mummies.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        private IMummyRepository _repo;

        private ApplicationDbContext context;


        public AdminController(ILogger<AdminController> logger, ApplicationDbContext temp, IMummyRepository _temp)
        {
            _logger = logger;
            context = temp;
            _repo = _temp;

        }

        ////////////////////
        /////   USERS
        ////////////////////
        ///
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Users()
        {

            var UserJoin = (from u in context.Users
                            join link in context.UserRoles
                            on u.Id equals link.UserId
                            join r in context.Roles
                            on link.RoleId equals r.Id
                            select new UserPageViewModel
                            {
                                UserRole = r.Name,
                                UserName = u.UserName,
                                UserId = u.Id
                            })
                       .ToList();
                
            

            return View(UserJoin);
        }

        ////////////////////
        /////   CRUD
        ////////////////////
        public IActionResult Crud(int pageNum = 1)
        {
            int pageSize = 1;
            //ViewBag.burialmain = from burialdata in _repo.burialdata
            //                     join burialmaintextiles in _repo.burialmaintextiles
            //                     on burialdata.Id equals burialmaintextiles.MainBurialmainid
            //                     select "*".ToList();

            //var BurialId = _repo.burialdata
            //    .OrderBy(p => p.Id).ToList();
            //var TextileId = _repo.burialmaintextiles.OrderBy(p => p.MainBurialmainid).ToList();

            //var burialInfo = (from t in _repo.textiles
            //            join bmt in _repo.burialmaintextiles
            //            on t.Id equals bmt.MainTextileid
            //            join bm in _repo.burialdata
            //            on bmt.MainBurialmainid equals bm.Id
            //            select new BurialPageModel
            //            {
            //                Id = bm.Id,
            //                TextileDescription = t.Description
            //            })
            //            .OrderBy(b => b.Id)
            //            .ToList();



            var data = new BurialsViewModel
            {
                Burialmains = _repo.burialdata
                .OrderBy(p => p.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                burialInfo = (from t in _repo.textiles
                              join bmt in _repo.burialmaintextiles
                              on t.Id equals bmt.MainTextileid
                              join bm in _repo.burialdata
                              on bmt.MainBurialmainid equals bm.Id
                              select new BurialPageModel
                              {
                                  Id = bm.Id,
                                  TextileDescription = t.Description
                              })
                        .OrderBy(b => b.Id)
                        .ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumBurial = _repo.burialdata.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(data);
        }

        ////////////////////
        /////   CREATE
        ////////////////////
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Burialmain create)
        {
            _repo.AddBurial(create);

            return View("AddConfirmation");
        }
        public IActionResult AddConfirmation()
        {
            return View();
        }
    }
}

