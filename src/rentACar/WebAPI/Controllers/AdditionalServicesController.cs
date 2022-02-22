using Application.Features.AdditionalServices.Commands.CreateAdditionalServices;
using Application.Features.AdditionalServices.Commands.DeleteAdditionalServices;
using Application.Features.AdditionalServices.Commands.UpdateAdditionalServices;
using Application.Features.AdditionalServices.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalServicesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAdditionalServiceCommand createAdditionalServiceCommand)
        {
            var result = await Mediator.Send(createAdditionalServiceCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdditionalServiceCommand updateAdditionalServiceCommand)
        {
            var result = await Mediator.Send(updateAdditionalServiceCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAdditionalServiceCommand deleteAdditionalServiceCommand)
        {
            var result = await Mediator.Send(deleteAdditionalServiceCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdditionalService()
        {
            var query = new GetListAdditionalServiceQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
