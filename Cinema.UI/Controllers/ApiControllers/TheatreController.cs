using Cinema.Business.Abstraction.Extensions;
using Cinema.UI.Helpers.ConstantHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers.ApiControllers
{
    [Route(Routes.TheatreAPI)]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly IExtendedTheatreService _theatreService;

        public TheatreController(IExtendedTheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet(Routes.GetAllTheatres)]
        public async Task<IActionResult> GetAllTheatres()
        {
            try
            {
                var theatres = (await _theatreService.GetAllAsync()).ToList();

                if (theatres != null)
                {
                    return Ok(theatres);
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
