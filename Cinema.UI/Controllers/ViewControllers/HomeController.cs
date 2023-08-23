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

        private readonly IExtendedSessionService _sessionService;

        public HomeController(IExtendedTheatreService theatreService, IExtendedLanguageService languageService, IExtendedSessionService sessionService)
        {
            _theatreService = theatreService;
            _languageService = languageService;
            _sessionService = sessionService;
        }

        public async Task<IActionResult> Index()
        {
            // Updating session dates so that their startTime Date will appear to be within the 7 days
            await _sessionService.AdjustSessionDatesToNextWeekAsync();

            var viewModel = new TodayMoviesViewModel()
            {
                Theatres = (await _theatreService.GetAllAsync()).ToList(),
                Languages = (await _languageService.GetAllAsync())
                 .Where(l => l.Name != ApplicationConstants.NotApplicable)
                 .Select(l => l.Name)
                 .Distinct()
                 .ToList(),
                SessionDates = (await _sessionService.GetAllAsync())
                 .Select(s => s.StartTime.Date) // Extract the date part of the StartTime
                 .Distinct()
                 .OrderBy(s => s.Day)
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