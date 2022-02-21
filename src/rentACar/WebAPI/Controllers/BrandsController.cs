using Application.Features.Brands.Commends.CreateBrand;
using Application.Features.Brands.Commends.DeleteBrand;
using Application.Features.Brands.Commends.UpdateBrand;
using Application.Features.Brands.Queries.GetAllBrandDetail;
using Application.Features.Brands.Queries.GetBrandById;
using Application.Features.Brands.Queries.GetBrandList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            var result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            var result = await Mediator.Send(updateBrandCommand);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            var result = await Mediator.Send(deleteBrandCommand);
            return Ok();
        }

        [HttpGet("get-brand-list")]
        public async Task<IActionResult> GetBrandList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetBrandListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetBrandById([FromBody] GetBrandByIdQuery getBrandByIdQuery)
        {
            var result = await Mediator.Send(getBrandByIdQuery);
            return Ok(result);
        }

        [HttpGet("get-brand-detail-list")]
        public async Task<IActionResult> GetBrandList()
        {
            var query = new GetAllBrandDetailQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
