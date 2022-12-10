using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tocatu.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tocatu.Context;
using Microsoft.EntityFrameworkCore;

namespace tocatu.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly TocatuContext _context;

    public HomeController(ILogger<HomeController> logger, TocatuContext context)
    {
      _logger = logger;
      _context = context;
    }

    //public IActionResult Index()
    //{
    //  return View();
    //}

    public async Task<IActionResult> Index()
    {
      return View(await _context.Eventos.ToListAsync());
    }

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
}
