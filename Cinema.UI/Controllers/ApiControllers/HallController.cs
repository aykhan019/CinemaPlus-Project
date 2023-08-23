using Cinema.Business.Abstraction.Extensions;
using Cinema.UI.Helpers.ConstantHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers.ApiControllers
{
    [Route(Routes.HallAPI)]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IExtendedHallService _hallService;

        public HallController(IExtendedHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpGet(Routes.GetAllHalls)]
        public async Task<IActionResult> GetAllHalls()
        {
            try
            {
                var halls = (await _hallService.GetAllAsync()).ToList();

                if (halls != null)
                {
                    return Ok(halls);
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
