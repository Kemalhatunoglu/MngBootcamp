using Application.Features.Cars.Commends.CreateCar;
using Application.Features.Cars.Commends.DeleteCar;
using Application.Features.Cars.Commends.UpdateCar;
using Application.Features.Cars.Queries;
using Core.Application.Requests;
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
        {
            await Mediator.Send(updateCarCommand);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand deleteCarCommand)
        {
            await Mediator.Send(deleteCarCommand);
            return Ok();
        }

        [HttpGet("get-car-list")]
        public async Task<IActionResult> GetBrandList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
