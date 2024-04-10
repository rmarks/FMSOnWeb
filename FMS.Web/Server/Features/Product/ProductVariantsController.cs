using FMS.Application.Features.Product.ProductVariants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FMS.Web.Server.Features.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductVariantsController>/dropdowns
        [HttpGet("dropdowns")]
        public async Task<IActionResult> Get()
        {
            var dto = await _mediator.Send(new GetProductVariantsDropdowns.Query());
            return dto == null ? NotFound() : Ok(dto);
        }

        // GET api/<ProductVariantsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dto = await _mediator.Send(new GetProductVariants.Query(id));
            return dto == null ? NotFound() : Ok(dto);
        }

        // POST api/<ProductVariantsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductVariantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
