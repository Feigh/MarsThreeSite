using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MarsThreeSite.Models;
using Microsoft.Extensions.Logging;
using MarsThreeSite.Controllers.Data_Access;
using MarsThreeSite.Data;

namespace MarsThreeSite.Controllers
{
    public class HomeController : Controller
    {
        ILogger<HomeController> _logger;
        IPageRepository _pageRepo;

        public HomeController(ILogger<HomeController> logger, IPageRepository respository)
        {
            _logger = logger;
            _pageRepo = respository;
        }

        public IActionResult Index()
        {
            return View(_pageRepo.GetPage());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
