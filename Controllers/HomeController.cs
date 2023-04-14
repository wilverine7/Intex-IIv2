using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mummies.Models;
using Mummies.Models.Repo;
using Mummies.Models.ViewModels;
using System.Collections.Generic;
namespace Mummies.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private IMummyRepository _repo;

    public HomeController(ILogger<HomeController> logger, IMummyRepository temp)
    {
        _logger = logger;
        _repo = temp;
        
    }

    ////////////////////
    /////   INDEX
    ////////////////////
    public IActionResult Index()
    {
        return View();
    }

    ////////////////////
    /////   BURIAL LIST
    ////////////////////
    public IActionResult BurialList(string Sex, string HeadDirection, string Depth, int pageNum = 1)
    {

        int pageSize = 20;

        if (Sex != null)
        {
            var data = new BurialsViewModel
            {
                //Burialmains = _repo.burialdata.Where(b => (b.Sex == Sex || b.Sex == null) && (b.Depth == Depth || b.Depth == null))
                //.OrderBy(p => p.Id)
                //.Skip((pageNum - 1) * pageSize)
                //.Take(pageSize),


                burialInfo = (from bm in _repo.burialdata
                              where ((bm.Sex == Sex) && (bm.Depth == Depth || Depth == null))
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
        else
        {
            var data = new BurialsViewModel
            {
                //Burialmains = _repo.burialdata.Where(b => (b.Sex == Sex || b.Sex == null) && (b.Depth == Depth || b.Depth == null))
                //.OrderBy(p => p.Id)
                //.Skip((pageNum - 1) * pageSize)
                //.Take(pageSize),


                burialInfo = (from bm in _repo.burialdata
                              where (bm.Depth == Depth || Depth == null)
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

                                  
                              })
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize).ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumBurial = _repo.burialdata.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }

                //TextileDict = TextileDict,
                //BurialIds = _repo.burialdata.OrderBy(p => p.Id).ToList()

            };
            return View(data);
        }
        
      }


    ////////////////////
    /////   SUPERVISED
    ////////////////////
    public IActionResult Supervised()
    {
        return View();
    }

    ////////////////////
    /////   UNSUPERVISED
    ////////////////////
    public IActionResult Unsupervised()
    {
        return View();
    }

    ////////////////////
    /////   PRIVACY
    ////////////////////
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult BurialDetails(long Id)
    {
        var DetailsData = new BurialDetailsViewModel
        {
            Details = (from t in _repo.textiles
                       join bmt in _repo.burialmaintextiles
                       on t.Id equals bmt.MainTextileid
                       join bm in _repo.burialdata
                       on bmt.MainBurialmainid equals bm.Id
                       where bm.Id == Id
                       select new BurialDetailsPageModel
                       {
                           TextileDescription = t.Description

                       })

                    .ToList(),
            Burialmains = (from bm in _repo.burialdata
                           where bm.Id == Id
                           select new BurialDetailsPageModel
                           {
                               BurialId = bm.Id,
                               Sex = bm.Sex,
                               Preservation = bm.Preservation,
                               Depth = bm.Depth,
                               Facebundles = bm.Facebundles,
                               Goods = bm.Goods,
                               Text = bm.Text,
                               Wrapping = bm.Wrapping,
                               HairColor = bm.Haircolor,
                               SamplesCollected = bm.Samplescollected,
                               Length = bm.Length,
                               AgeatDeath = bm.Ageatdeath
                           })
                           .ToList(),
            DirectionData = (from bm in _repo.burialdata
                             where bm.Id == Id
                             select new BurialDetailsPageModel
                             {
                                 SouthtoHead = bm.Southtohead,
                                 WesttoHead = bm.Westtohead,
                                 SouthtoFeet = bm.Southtofeet,
                                 WesttoFeet = bm.Southtofeet
                             })
                           .ToList(),
            PhotoData = (from pd in _repo.photodata
                         join pdt in _repo.photodatatextiles on pd.Id equals pdt.MainPhotodataid
                         join t in _repo.textiles on pdt.MainTextileid equals t.Id
                         join bmt in _repo.burialmaintextiles on t.Id equals bmt.MainTextileid
                         where bmt.MainBurialmainid == Id
                         select new BurialDetailsPageModel
                         {
                             PhotoUrl = pd.Url,
                             TextileDescription = t.Description

                         }).ToList(),
            CompositeId = (from bm in _repo.burialdata
                           where bm.Id == Id
                           select new BurialDetailsPageModel
                           {
                               CompKey = (bm.Squarenorthsouth + bm.Northsouth +"/"+ bm.Squareeastwest + bm.Eastwest +"/"+ bm.Area + bm.Burialnumber)
                           }).ToList(),
            KeyDictionary = new ImageDictionary(),
            


        };
    return View(DetailsData);
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

