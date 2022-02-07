using Application.Features.IndividualCustomer.Commends.CreateIndividualCustomer;
using Application.Features.IndividualCustomer.Commends.DeleteIndividualCustomer;
using Application.Features.IndividualCustomer.Commends.UpdateIndividualCustomer;
using Application.Features.IndividualCustomer.Queries.GetIndividualCustomerById;
using Application.Features.IndividualCustomer.Queries.GetIndividualCustomerList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomerController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateIndividualCustomerCommand createIndividualCustomerCommand)
        {
            var result = await Mediator.Send(createIndividualCustomerCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerCommand updateIndividualCustomerCommand)
        {
            var result = await Mediator.Send(updateIndividualCustomerCommand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteIndividualCustomerCommand deleteIndividualCustomerCommand)
        {
            var result = await Mediator.Send(deleteIndividualCustomerCommand);
            return Ok(result);
        }

        [HttpGet("get-individual-customer-list")]
        public async Task<IActionResult> GetIndividualList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetIndividualCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetIndividualCustomerById([FromQuery] GetIndividualCustomerByIdQuery getIndividualCustomerByIdQuery)
        {
            var result = await Mediator.Send(getIndividualCustomerByIdQuery);
            return Ok(result);
        }
    }
}
