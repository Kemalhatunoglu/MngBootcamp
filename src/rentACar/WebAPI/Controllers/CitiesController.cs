using Application.Features.Cities.Commands.CreateCity;
using Application.Features.Cities.Commands.DeleteCity;
using Application.Features.Cities.Commands.UpdateCity;
using Application.Features.Cities.Queries.GetListCities;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCityCommand createCityCommand)
        {
            var result = await Mediator.Send(createCityCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCityCommand)
        {
            var result = await Mediator.Send(updateCityCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCityCommand deleteCityCommand)
        {
            var result = await Mediator.Send(deleteCityCommand);
            return Created("", result);
        }

        [HttpGet("get-city-list")]
        public async Task<IActionResult> GetCityList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCityListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
