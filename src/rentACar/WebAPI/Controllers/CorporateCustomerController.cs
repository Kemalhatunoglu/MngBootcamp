using Application.Features.CorporateCustomer.Commends.CreateCorporateCustomer;
using Application.Features.CorporateCustomer.Commends.DeleteCorporateCustomer;
using Application.Features.CorporateCustomer.Commends.UpdateCorporateCustomer;
using Application.Features.CorporateCustomer.Queries.GetCorporateCustomerById;
using Application.Features.CorporateCustomer.Queries.GetCorporateCustomerList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCustomerController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
        {
            var result = await Mediator.Send(createCorporateCustomerCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
        {
            var result = await Mediator.Send(updateCorporateCustomerCommand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCorporateCustomerCommand deleteCorporateCustomerCommand)
        {
            var result = await Mediator.Send(deleteCorporateCustomerCommand);
            return Ok(result);
        }

        [HttpGet("get-corporate-customer-list")]
        public async Task<IActionResult> GetCorporateList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCorporateCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetCorporateCustomerById([FromQuery] GetCorporateCustomerByIdQuery getCorporateCustomerByIdQuery)
        {
            var result = await Mediator.Send(getCorporateCustomerByIdQuery);
            return Ok(result);
        }
    }
}
