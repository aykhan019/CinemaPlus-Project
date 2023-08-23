using Cinema.Business.Abstraction.Extensions;
using Cinema.Entities.Models;
using Cinema.UI.Helpers.ConstantHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers.ApiControllers
{
    [Route(Routes.SessionAPI)]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IExtendedSessionService _sessionService;

        private readonly IExtendedHallService _hallService;

        private readonly IExtendedMovieService _movieService;

        private readonly IExtendedLanguageService _languageService;


        public SessionController(IExtendedSessionService sessionService, IExtendedHallService hallService, IExtendedMovieService movieService, IExtendedLanguageService languageService)
        {
            _sessionService = sessionService;
            _hallService = hallService;
            _movieService = movieService;
            _languageService = languageService;
        }

        [HttpGet(Routes.GetAllSessions)]
        public async Task<IActionResult> GetAllSessions()
        {
            try
            {
                var sessions = await _sessionService.GetAllAsync();

                if (sessions != null)
                {
                    var list = sessions.ToList();

                    list.ForEach(async (session) =>
                    {
                        session.Hall = await _hallService.GetByIdAsync(session.HallId);

                        session.Movie = await _movieService.GetByIdAsync(session.MovieId);

                        session.Movie.Languages = (await _languageService.GetMovieLanguages(session.Movie.Id)).ToList();
                    });

                    return Ok(list);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
