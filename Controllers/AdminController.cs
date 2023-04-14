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
        private UserManager<IdentityUser> userManager;
        private IPasswordHasher<IdentityUser> passwordHasher;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext temp, IMummyRepository _temp, UserManager<IdentityUser> usrMgr, IPasswordHasher<IdentityUser> passwordHash)
        {
            _logger = logger;
            context = temp;
            _repo = _temp;
            userManager = usrMgr;
            passwordHasher = passwordHash;

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

        

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string Id)
        {
            IdentityUser user = await userManager.FindByIdAsync(Id);
            if (user != null)
                return RedirectToAction("Users");
            else
                return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string Id, string Role)
        {
            IdentityUser user = await userManager.FindByIdAsync(Id);
            var link = context.UserRoles.Single(x => x.UserId == user.Id);
            var rolerow = context.Roles.Single(x => link.RoleId == x.Id);

            rolerow.Name = Role;
            //IdentityRole role = await manage.   RManager.FindByIdAsync(Id)
            if (user != null)
            {
                
                IdentityResult result = await userManager.UpdateAsync(user);
                
                if (result.Succeeded)
                    return RedirectToAction("Users");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return RedirectToAction("Users");
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
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
        public IActionResult Delete(Burialmain delete)
        {
            _repo.DeleteBurial(delete);

            return RedirectToAction("Crud");
        }
    }
}

