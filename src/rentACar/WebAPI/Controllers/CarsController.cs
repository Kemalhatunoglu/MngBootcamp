using Application.Features.Cars.Commends.CreateCar;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add(CreateCarCommand createCarCommand)
        {
            var result = await Mediator.Send(createCarCommand);
            return Created("", result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] CreateCarCommand createCarCommand)
        {
            await Mediator.Send(createCarCommand);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] CreateCarCommand createCarCommand)
        {
            await Mediator.Send(createCarCommand);
            return Ok();
        }
    }
}
