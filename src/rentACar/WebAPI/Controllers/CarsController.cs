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

        [HttpPut("car-state-update")]
        public async Task<IActionResult> CarStateUpdate([FromBody] UpdateCarStateCommand updateCarStateCommand)
        {
            await Mediator.Send(updateCarStateCommand);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand deleteCarCommand)
        {
            await Mediator.Send(deleteCarCommand);
            return Ok();
        }

        [HttpGet("get-car-list")]
        public async Task<IActionResult> GetCarList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-by-cityId")]
        public async Task<IActionResult> GetCarById([FromQuery] GetCarListByCityIdQuery getCarListByCityIdQuery)
        {
            var result = await Mediator.Send(getCarListByCityIdQuery);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetCarById([FromQuery] GetCarByIdQuery getCarByIdQuery)
        {
            var result = await Mediator.Send(getCarByIdQuery);
            return Ok(result);
        }
    }
}
