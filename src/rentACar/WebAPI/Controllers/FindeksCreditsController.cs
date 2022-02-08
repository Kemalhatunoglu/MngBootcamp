using Application.Features.FindeksCredits.Command.CreateFindeksCredit;
using Application.Features.FindeksCredits.Command.DeleteFindeksCredit;
using Application.Features.FindeksCredits.Command.UpdateFindeksCredit;
using Application.Features.FindeksCredits.Queries.GetFindeksCreditByCustomerId;
using Application.Features.FindeksCredits.Queries.GetFindeksCreditById;
using Application.Features.FindeksCredits.Queries.GetListFindeksCredit;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksCreditsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateFindeksCreditCommand createFindeksCreditCommand)
        {
            var result = await Mediator.Send(createFindeksCreditCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateFindeksCreditCommand updateFindeksCreditCommand)
        {
            var result = await Mediator.Send(updateFindeksCreditCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteFindeksCreditCommand deleteFindeksCreditCommand)
        {
            var result = await Mediator.Send(deleteFindeksCreditCommand);
            return Created("", result);
        }

        [HttpGet("get-findeks-credit-list")]
        public async Task<IActionResult> GetFindeksCreditList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetListFindeksRateQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetFindeksCreditById([FromBody] GetFindeksCreditByIdQuery getFindeksCreditByIdQuery)
        {
            var result = await Mediator.Send(getFindeksCreditByIdQuery);
            return Ok(result);
        }

        [HttpGet("get-by-customerId")]
        public async Task<IActionResult> GetFindeksCreditById([FromBody] GetFindeksCreditByCustomerIdQuery getFindeksCreditByCustomerIdQuery)
        {
            var result = await Mediator.Send(getFindeksCreditByCustomerIdQuery);
            return Ok(result);
        }
    }
}
