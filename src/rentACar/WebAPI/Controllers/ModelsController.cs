using Application.Features.Models.Commends.CreateModel;
using Application.Features.Models.Commends.DeleteModel;
using Application.Features.Models.Commends.UpdateModel;
using Application.Features.Models.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
        {
            var result = await Mediator.Send(createModelCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateModelCommand updateModelCommand)
        {
            await Mediator.Send(updateModelCommand);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteModelCommand deleteModelCommand)
        {
            await Mediator.Send(deleteModelCommand);
            return Ok();
        }

        [HttpGet("get-model-list")]
        public async Task<IActionResult> GetBrandList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetModelListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
