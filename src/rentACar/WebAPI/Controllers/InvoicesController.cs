using Application.Features.Invoices.Command.CreateInvoice;
using Application.Features.Invoices.Command.DeleteInvoice;
using Application.Features.Invoices.Command.UpdateInvoice;
using Application.Features.Invoices.Queries.GetInvoiceByDateQuery;
using Application.Features.Invoices.Queries.GetInvoiceListByCustomerId;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateInvoiceCommand createInvoiceCommand)
        {
            var result = await Mediator.Send(createInvoiceCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateInvoiceCommand updateInvoiceCommand)
        {
            var result = await Mediator.Send(updateInvoiceCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInvoiceCommand deleteInvoiceCommand)
        {
            var result = await Mediator.Send(deleteInvoiceCommand);
            return Created("", result);
        }

        [HttpGet("get-by-customerId")]
        public async Task<IActionResult> GetInvoiceById([FromBody] GetInvoiceListByCustomerQuery getInvoiceListByCustomerQuery)
        {
            var result = await Mediator.Send(getInvoiceListByCustomerQuery);
            return Ok(result);
        }

        [HttpGet("get-by-between-date")]
        public async Task<IActionResult> GetInvoiceBetweenDate([FromBody] GetInvoiceListByDateQuery getInvoiceListByDateQuery)
        {
            var result = await Mediator.Send(getInvoiceListByDateQuery);
            return Ok(result);
        }
    }
}
