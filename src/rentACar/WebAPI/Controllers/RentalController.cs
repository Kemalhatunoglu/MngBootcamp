using Application.Features.Rentals.Commands.CreateRental;
using Application.Features.Rentals.Commands.DeleteRental;
using Application.Features.Rentals.Commands.UpdateRental;
using Application.Features.Rentals.Queries.GetRentalList;
using Core.Application.Requests;
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRentalCommand updateRentalCommand)
        {
            var result = await Mediator.Send(updateRentalCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteRentalCommand deleteRentalCommand)
        {
            var result = await Mediator.Send(deleteRentalCommand);
            return Created("", result);
        }

        [HttpGet("get-rental-list")]
        public async Task<IActionResult> GetRentalList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetRentalListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
