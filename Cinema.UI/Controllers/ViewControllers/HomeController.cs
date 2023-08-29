using Cinema.Business.Abstraction.Extensions;
using Cinema.Entities.Helpers;
using Cinema.UI.Extensions;
using Cinema.UI.Helpers.ConstantHelpers;
using Cinema.UI.Models;
using CinemaPlusMovieDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cinema.UI.Controllers.ViewControllers
{
    public class HomeController : Controller
    {
        private readonly IExtendedTheatreService _theatreService;

        private readonly IExtendedLanguageService _languageService;

        private readonly IExtendedSessionService _sessionService;

        private readonly IExtendedMovieService _movieService;

        private readonly IExtendedSubtitleService _subtitleService;

        private readonly IExtendedHallService _hallService;

        public HomeController(IExtendedTheatreService theatreService, IExtendedLanguageService languageService, IExtendedSessionService sessionService, IExtendedMovieService movieService, IExtendedSubtitleService subtitleService, IExtendedHallService hallService)
        {
            _theatreService = theatreService;
            _languageService = languageService;
            _sessionService = sessionService;
            _movieService = movieService;
            _subtitleService = subtitleService;
            _hallService = hallService;
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

        public async Task<IActionResult> Movies(string id = ApplicationConstants.StringEmpty)
        {
            string movieId = id;

            if (movieId == ApplicationConstants.StringEmpty)
                return NoContent();

            var movie = await _movieService.GetByIdAsync(movieId);

            if (movie == null)
                return NotFound();


            if (movie.TrailerUrl != null && movie.TrailerUrl.Contains(ApplicationConstants.WatchQueryString))
            {
                // Replace the string with the constant
                movie.TrailerUrl = movie.TrailerUrl.Replace(ApplicationConstants.WatchQueryString, ApplicationConstants.EmbedString);
            }

            var sessions = (await _sessionService.GetMovieSessionsAsync(movieId)).ToList();

            var languages = await _languageService.GetMovieLanguagesAsync(movieId);

            var subtitles = await _subtitleService.GetMovieSubtitlesAsync(movie.Id);

            // Select a random set of movies (one extra) from the list of all movies, which may include the current movie to be displayed, 
            // and intend to remove 1 movie if it happens to be the current one being displayed.
            var anotherMovies = (await _movieService.GetAllAsync())
                .ToList().GetRandomDistinctElements(ApplicationConstants.AnotherMoviesCount + 1);

            anotherMovies.RemoveAll(m => m.Id == movie.Id);

            anotherMovies = anotherMovies.Take(4).ToList();

            anotherMovies.ForEach(async (anotherMovie) =>
            {
                anotherMovie.Subtitles = (await _subtitleService.GetMovieSubtitlesAsync(anotherMovie.Id)).ToList();

                anotherMovie.Languages = (await _languageService.GetMovieLanguagesAsync(anotherMovie.Id)).ToList();
            });

            sessions.ForEach(async session =>
            {
                session.Hall = await _hallService.GetByIdAsync(session.HallId);

                if (session.Hall != null)
                    session.Hall.Theatre = await _theatreService.GetByIdAsync(session.Hall.TheatreId);

                session.Movie = movie;

                if (session.Movie != null)
                {
                    session.Movie.Languages = languages.ToList();

                    session.Movie.Subtitles = subtitles.ToList();
                }
            });

            var viewModel = new MovieDetailsViewModel()
            {
                Movie = movie,
                MovieSessions = sessions,
                AnotherMovies = anotherMovies,
                SessionDates = Enumerable.Range(0, 7).Select(offset => DateTime.Now.Date.AddDays(offset)).ToList(),
                Languages = (await _languageService.GetAllAsync()).Select(l => l.Name).Distinct().ToList(),
                Theatres = (await _theatreService.GetAllAsync()).ToList()
            };

            return View(ApplicationConstants.MovieView, viewModel);
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