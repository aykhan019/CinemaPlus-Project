using Cinema.Business.Abstraction.Extensions;
using Cinema.UI.Helpers.ConstantHelpers;
using Cinema.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cinema.UI.Controllers.ViewControllers
{
    public class HomeController : Controller
    {
        private readonly IExtendedTheatreService _theatreService;

        private readonly IExtendedLanguageService _languageService;

        public HomeController(IExtendedTheatreService theatreService, IExtendedLanguageService languageService)
        {
            _theatreService = theatreService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new TodayMoviesViewModel()
            {
                Theatres = (await _theatreService.GetAllAsync()).ToList(),
                Languages = (await _languageService.GetAllAsync())
                 .Where(l => l.Name != ApplicationConstants.NotApplicable)
                 .Select(l => l.Name)
                 .Distinct()
                 .ToList()
            };
            return View(viewModel);
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