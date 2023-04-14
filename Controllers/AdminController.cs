using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mummies.Models;
using Mummies.Models.Repo;
using Mummies.Models.ViewModels;

namespace Mummies.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        private IMummyRepository _repo;

        public AdminController(ILogger<AdminController> logger, IMummyRepository temp)
        {
            _logger = logger;
            _repo = temp;

        }

        ////////////////////
        /////   USERS
        ////////////////////
        ///
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Users()
        {
            return View();
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

