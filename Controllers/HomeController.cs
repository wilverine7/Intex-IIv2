using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mummies.Models;
using Mummies.Models.Repo;
using Mummies.Models.ViewModels;
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
    public IActionResult BurialList(int pageNum = 1)
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

