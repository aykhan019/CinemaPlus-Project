using Cinema.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.UI.Controllers.ViewControllers
{
    public class HomeController : Controller
    {
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