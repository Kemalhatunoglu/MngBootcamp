using Application.Features.Transmissions.Commends.CreateTransmission;
using Application.Features.Transmissions.Commends.DeleteTransmission;
using Application.Features.Transmissions.Commends.UpdateTransmission;
using Application.Features.Transmissions.Queries.GetTransmissionList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
        {
            var result = await Mediator.Send(createTransmissionCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand updateTransmissionCommand)
        {
            var result = await Mediator.Send(updateTransmissionCommand);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTransmissionCommand deleteTransmissionCommand)
        {
            var result = await Mediator.Send(deleteTransmissionCommand);
            return Ok();
        }

        [HttpGet("get-transmission-list")]
        public async Task<IActionResult> GetTransmissionsList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetTransmissionListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
