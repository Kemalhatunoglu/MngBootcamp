using Application.Features.DamageRecords.Commands.CreateDamageRecord;
using Application.Features.DamageRecords.Commands.DeleteDamageRecord;
using Application.Features.DamageRecords.Commands.UpdateDamageRecord;
using Application.Features.DamageRecords.Queries.GetDamageRecordList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageRecordsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDamageRecordCommand createDamageRecordCommand)
        {
            var result = await Mediator.Send(createDamageRecordCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateDamageRecordCommand updateDamageRecordCommand)
        {
            var result = await Mediator.Send(updateDamageRecordCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteDamageRecordCommand deleteDamageRecordCommand)
        {
            var result = await Mediator.Send(deleteDamageRecordCommand);
            return Created("", result);
        }

        [HttpGet("get-damage-record-list")]
        public async Task<IActionResult> GetDamageRecordList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetDamageRecordListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
