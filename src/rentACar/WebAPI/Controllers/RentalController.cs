using Application.Features.Rentals.Commands.CreateRental;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateRentalCommand createRentalCommand)
        {
            var result = await Mediator.Send(createRentalCommand);
            return Created("", result);
        }
    }
}
