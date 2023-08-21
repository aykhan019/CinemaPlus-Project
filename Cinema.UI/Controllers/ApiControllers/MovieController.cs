using Cinema.Business.Abstraction;
using Cinema.UI.Helpers.ConstantHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers.ApiControllers
{
    [Route(Routes.MovieAPI)]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet(Routes.GetAllMovies)]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var movies = await _movieService.GetAll();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
