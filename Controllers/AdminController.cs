using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Users()
        {
            return View();
        }

        ////////////////////
        /////   CRUD
        ////////////////////
        public IActionResult Crud(string Sex, string HeadDirection, string Depth, int pageNum = 1)
        {

            int pageSize = 20;

            var data = new BurialsViewModel
            {
                //Burialmains = _repo.burialdata.Where(b => (b.Sex == Sex || b.Sex == null) && (b.Depth == Depth || b.Depth == null))
                //.OrderBy(p => p.Id)
                //.Skip((pageNum - 1) * pageSize)
                //.Take(pageSize),


                burialInfo = (from bm in _repo.burialdata
                              where ((bm.Sex == Sex || Sex == null) && (bm.Depth == Depth || Depth == null))
                              orderby bm.Id
                              select new BurialPageModel
                              {
                                  Id = bm.Id,
                                  Sex = bm.Sex,
                                  //TextileDescription = t.Description,

                                  //this is how we want it
                                  //Preservation = bm.Preservation,
                                  //TextileId = t.Id,
                                  //TextileStructure = s.Value,
                                  //TextileColor = c.Value,
                                  //Sex = bm.Sex,
                                  BurialDepth = bm.Depth,
                                  //Age = bm.Ageatdeath,
                                  //HeadDirection = bm.Headdirection,
                                  //TextileFunction = tf.Value,
                                  BurialId = (bm.Squarenorthsouth + bm.Northsouth + "/" + bm.Squareeastwest + bm.Eastwest + "/" + bm.Area + bm.Burialnumber)

                                  //need to import csv to database
                                  //EstimatedStature = 
                              })
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize).ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumBurial = _repo.burialdata.Where(b => (b.Sex == Sex || b.Sex == null) && (b.Depth == Depth || b.Depth == null)).Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }

                //TextileDict = TextileDict,
                //BurialIds = _repo.burialdata.OrderBy(p => p.Id).ToList()

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

        ////////////////////
        /////   UPDATE
        ////////////////////
        [HttpGet]
        public IActionResult Update(long burialid)
        {
            var burial = _repo.GetBurial(burialid);

            return View(burial);
        }
        [HttpPost]
        public IActionResult Update(Burialmain update)
        {
            _repo.UpdateBurial(update);

            return RedirectToAction("Crud");
        }

        ////////////////////
        /////   DELETE
        ////////////////////
        [HttpGet]
        public IActionResult Delete(long burialid)
        {
            var burial = _repo.GetBurial(burialid);

            return View(burial);
        }
        [HttpPost]
        public IActionResult Delete(long delete, bool confirm)
        {
            if (confirm)
            {
                _repo.DeleteBurial(delete);
            }

            return RedirectToAction("Crud");
        }
    }
}

