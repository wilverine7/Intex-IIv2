using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mummies.Models;
using Mummies.Models.Repo;

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
        int pageSize = 5;
        //ViewBag.burialmain = from burialdata in _repo.burialdata
        //            join burialmaintextiles in _repo.burialmaintextiles
        //            on burialdata.Id equals burialmaintextiles.MainBurialmainid
        //            select "*".ToList();


        var blah = _repo.burialdata
            .OrderBy(p => p.Id)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);
        return View(blah);
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

