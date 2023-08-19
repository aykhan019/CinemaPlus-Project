using Cinema.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Platinum()
        {
            return View();
        }

       public IActionResult DolbyAtmos()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}