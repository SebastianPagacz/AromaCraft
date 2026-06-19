using AromaCraft.Application.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AromaCraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand request)
        {
            var result = await _mediator.Send(request);

            if(result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result.Message);
        }
    }
}
