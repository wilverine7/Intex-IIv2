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
    public IActionResult BurialList(string Sex, string HeadDirection, int pageNum = 1)
    {


        // creates list of Id's 
        //var BurialIds= _repo.burialdata.OrderBy(p => p.Id).ToList();

        //initialize dictionary 
        //Dictionary<long, List<TextileData>> TextileDict = new Dictionary<long, List<TextileData>>();

        //get the Associated Textile info for each Id and assign it to a dictionary 
        //foreach (var id in BurialIds)
        //{
        //var TextileInfo = (from t in _repo.textiles
        //                   join bmt in _repo.burialmaintextiles
        //                   on t.Id equals bmt.MainTextileid

        //                   join bm in _repo.burialdata
        //                   on bmt.MainBurialmainid equals bm.Id

        //                   join ct in _repo.colortextiles
        //                   on t.Id equals ct.MainTextileid

        //                   join c in _repo.colors
        //                   on ct.MainColorid equals c.Id

        //                   join st in _repo.structuretextiles
        //                   on t.Id equals st.MainTextileid

        //                   join s in _repo.structures
        //                   on st.MainStructureid equals s.Id

        //                   join tft in _repo.textilefunctiontextiles
        //                   on t.Id equals tft.MainTextileid

        //                   join tf in _repo.textilefunctions
        //                   on tft.MainTextilefunctionid equals tf.Id

        //                   where bm.Id == id.Id
        //     select new TextileData
        //     {
        //         TextileId = t.Id,
        //         TextileStructure = s.Value,
        //         TextileColor = c.Value,

                           //need to import csv to database
                           //EstimatedStature = 

                           //     })
                           //            .ToList();

                           //    TextileDict.Add(id.Id, TextileInfo);


                           //}


        int pageSize = 25;
        

        /////////
        //filter by sex
        /////////
        if (Sex != null)
            {
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
                              where (bm.Sex == Sex)
                              select new BurialPageModel
                              {
                                  Id = bm.Id,
                                  Sex = bm.Sex,
                                  TextileDescription = t.Description,

                                  //this is how we want it

                                  //TextileId = t.Id,
                                  //TextileStructure = s.Value,
                                  //TextileColor = c.Value,
                                  //Sex = bm.Sex,
                                  BurialDepth = bm.Depth,
                                  //Age = bm.Ageatdeath,
                                  //HeadDirection = bm.Headdirection,
                                  //TextileFunction = tf.Value,
                                  BurialId = (bm.Squarenorthsouth + bm.Northsouth + bm.Squareeastwest + bm.Eastwest + bm.Area + bm.Burialnumber)

                                  //need to import csv to database
                                  //EstimatedStature = 
                              })

                        .ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumBurial = _repo.burialdata.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },

                //TextileDict = TextileDict,
                //BurialIds = _repo.burialdata.OrderBy(p => p.Id).ToList()

            };
            return View(data);
        }
        else
        {
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
                                  Sex = bm.Sex,
                                  TextileDescription = t.Description,

                                  //this is how we want it

                                  //TextileId = t.Id,
                                  //TextileStructure = s.Value,
                                  //TextileColor = c.Value,
                                  //Sex = bm.Sex,
                                  BurialDepth = bm.Depth,
                                  //Age = bm.Ageatdeath,
                                  //HeadDirection = bm.Headdirection,
                                  //TextileFunction = tf.Value,
                                  BurialId = (bm.Squarenorthsouth + bm.Northsouth + bm.Squareeastwest + bm.Eastwest + bm.Area + bm.Burialnumber)

                                  //need to import csv to database
                                  //EstimatedStature = 
                              })

                        .ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumBurial = _repo.burialdata.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },

                //TextileDict = TextileDict,
                //BurialIds = _repo.burialdata.OrderBy(p => p.Id).ToList()

            };
            return View(data);
        }

        /////////
        //filter by Burial ID
        //////////
        
        //if (HeadDirection != null)
        //{
        //    var data = new BurialsViewModel
        //    {
        //        Burialmains = _repo.burialdata
        //            .OrderBy(p => p.Id)
        //            .Skip((pageNum - 1) * pageSize)
        //            .Take(pageSize),


        //        burialInfo = (from t in _repo.textiles
        //                      join bmt in _repo.burialmaintextiles
        //                      on t.Id equals bmt.MainTextileid
        //                      join bm in _repo.burialdata
        //                      on bmt.MainBurialmainid equals bm.Id
        //                      where (bm.Headdirection == HeadDirection)
        //                      select new BurialPageModel
        //                      {
        //                          Id = bm.Id,
        //                          Sex = bm.Sex,
        //                          TextileDescription = t.Description,

        //                          //this is how we want it

        //                          //TextileId = t.Id,
        //                          //TextileStructure = s.Value,
        //                          //TextileColor = c.Value,
        //                          //Sex = bm.Sex,
        //                          BurialDepth = bm.Depth,
        //                          //Age = bm.Ageatdeath,
        //                          //HeadDirection = bm.Headdirection,
        //                          //TextileFunction = tf.Value,
        //                          BurialId = (bm.Squarenorthsouth + bm.Northsouth + bm.Squareeastwest + bm.Eastwest + bm.Area + bm.Burialnumber)

        //                          //need to import csv to database
        //                          //EstimatedStature = 
        //                      })

        //                    .ToList(),

        //        PageInfo = new PageInfo
        //        {
        //            TotalNumBurial = _repo.burialdata.Count(),
        //            BurialsPerPage = pageSize,
        //            CurrentPage = pageNum
        //        },

                

        //    };
        //    return View(data);
        //}
        //else
        //{
        //    var data = new BurialsViewModel
        //    {
        //        Burialmains = _repo.burialdata
        //        .OrderBy(p => p.Id)
        //        .Skip((pageNum - 1) * pageSize)
        //        .Take(pageSize),


        //        burialInfo = (from t in _repo.textiles
        //                      join bmt in _repo.burialmaintextiles
        //                      on t.Id equals bmt.MainTextileid
        //                      join bm in _repo.burialdata
        //                      on bmt.MainBurialmainid equals bm.Id
        //                      select new BurialPageModel
        //                      {
        //                          Id = bm.Id,
        //                          Sex = bm.Sex,
        //                          TextileDescription = t.Description,

        //                          //this is how we want it

        //                          //TextileId = t.Id,
        //                          //TextileStructure = s.Value,
        //                          //TextileColor = c.Value,
        //                          //Sex = bm.Sex,
        //                          BurialDepth = bm.Depth,
        //                          //Age = bm.Ageatdeath,
        //                          //HeadDirection = bm.Headdirection,
        //                          //TextileFunction = tf.Value,
        //                          BurialId = (bm.Squarenorthsouth + bm.Northsouth + bm.Squareeastwest + bm.Eastwest + bm.Area + bm.Burialnumber)

        //                          //need to import csv to database
        //                          //EstimatedStature = 
        //                      })

        //                .ToList(),

        //        PageInfo = new PageInfo
        //        {
        //            TotalNumBurial = _repo.burialdata.Count(),
        //            BurialsPerPage = pageSize,
        //            CurrentPage = pageNum
        //        },

        //        //TextileDict = TextileDict,
        //        //BurialIds = _repo.burialdata.OrderBy(p => p.Id).ToList()

        //    };
        //    return View(data);
        //}


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
                               BurialId = bm.Id
                           })
                           .ToList(),
            PhotoData = (from pd in _repo.photodata
                         join pdt in _repo.photodatatextiles on pd.Id equals pdt.MainPhotodataid
                         join t in _repo.textiles on pdt.MainTextileid equals t.Id
                         join bmt in _repo.burialmaintextiles on t.Id equals bmt.MainTextileid
                         where bmt.MainBurialmainid == Id
                         select new BurialDetailsPageModel
                         {
                             PhotoUrl = pd.Url
                         }).ToList(),
            CompositeId = (from bm in _repo.burialdata
                          where bm.Id == Id
                          select new BurialDetailsPageModel
                          {
                              CompKey = (bm.Squarenorthsouth + bm.Northsouth + bm.Squareeastwest + bm.Eastwest + bm.Area + bm.Burialnumber)
                          }).ToList()


    };
    return View(DetailsData);
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

