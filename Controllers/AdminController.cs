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
        public IActionResult Crud(string BurialNumber, string FaceBundles, string Age, string Haircolor, string Sex, string HeadDirection, string Depth, string SquareNorthSouth, string SquareEastWest, string EastWest, string NorthSouth, string Area, int pageNum = 1)
        {

            int pageSize = 20;


            var data = new BurialsViewModel
            {
                burialInfo = (from bm in _repo.burialdata
                              where ((bm.Sex == Sex || Sex == null || Sex == "")
                              && (bm.Depth == Depth || Depth == null)
                              && (bm.Haircolor == Haircolor || Haircolor == null || Haircolor == "")
                              && (bm.Ageatdeath == Age || Age == null || Age == "")
                              && (bm.Headdirection == HeadDirection || HeadDirection == null || HeadDirection == "")
                              && (bm.Facebundles == FaceBundles || FaceBundles == null || FaceBundles == "")
                              && (bm.Squareeastwest == SquareEastWest || SquareEastWest == null || SquareEastWest == "")
                              && (bm.Eastwest == EastWest || EastWest == null || EastWest == "")
                              && (bm.Squarenorthsouth == SquareNorthSouth || SquareNorthSouth == null || SquareNorthSouth == "")
                              && (bm.Northsouth == NorthSouth || NorthSouth == null || NorthSouth == "")
                              && (bm.Area == Area || Area == null || Area == "")
                              && (bm.Burialnumber == BurialNumber || BurialNumber == null || BurialNumber == "")
                              )

                              //orderby bm.Id
                              select new BurialPageModel
                              {
                                  Id = bm.Id,
                                  Sex = bm.Sex,
                                  Haircolor = bm.Haircolor,
                                  BurialDepth = bm.Depth,
                                  Age = bm.Ageatdeath,
                                  HeadDirection = bm.Headdirection,
                                  //TextileFunction = tf.Value,
                                  BurialId = (bm.Squarenorthsouth + bm.Northsouth + "/" + bm.Squareeastwest + bm.Eastwest + "/" + bm.Area + bm.Burialnumber),
                                  FaceBundles = bm.Facebundles,
                                  //need to import csv to database
                                  //EstimatedStature = 
                              })
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize).ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumBurial = _repo.burialdata.Where(b => ((b.Sex == Sex || Sex == null || Sex == "")
                              && (b.Depth == Depth || Depth == null)
                              && (b.Haircolor == Haircolor || Haircolor == null || Haircolor == "")
                              && (b.Ageatdeath == Age || Age == null || Age == "")
                              && (b.Headdirection == HeadDirection || HeadDirection == null || HeadDirection == "")
                              && (b.Facebundles == FaceBundles || FaceBundles == null || FaceBundles == "")
                              && (b.Squareeastwest == SquareEastWest || SquareEastWest == null || SquareEastWest == "")
                              && (b.Eastwest == EastWest || EastWest == null || EastWest == "")
                              && (b.Squarenorthsouth == SquareNorthSouth || SquareNorthSouth == null || SquareNorthSouth == "")
                              && (b.Northsouth == NorthSouth || NorthSouth == null || NorthSouth == "")
                              && (b.Area == Area || Area == null || Area == "")
                              && (b.Burialnumber == BurialNumber || BurialNumber == null || BurialNumber == ""))).Count(),
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

        ////////////////////
        /////   UPDATE
        ////////////////////
        [HttpGet]
        public IActionResult Edit(long burialid)
        {
            var burial = _repo.GetBurial(burialid);

            return View(burial);
        }
        [HttpPost]
        public IActionResult Edit(Burialmain Edit)
        {
            _repo.UpdateBurial(Edit);

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

