using FMS.Application.Features.Product.ProductBasics;
using FMS.Web.Shared.Features.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Web.Server.Features.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBasicsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductBasicsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductBasicsController>/dropdowns
        [HttpGet("dropdowns")]
        public async Task<IActionResult> Get()
        {
            var dto = await _mediator.Send(new GetProductBasicsDropdowns.Query());
            return dto == null ? NotFound() : Ok(dto);
        }

        // GET api/<ProductBasicsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dto = await _mediator.Send(new GetProductBasics.Query(id));
            return dto == null ? NotFound() : Ok(dto);
        }

        // POST api/<ProductBasicsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductBasicsDto dto)
        {
            var newDto = await _mediator.Send(new AddProductBasics.Command(dto));

            return CreatedAtAction(nameof(Get), new { id = newDto.Id }, newDto);
        }

        // PUT api/<ProductBasicsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductBasicsDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateProductBasics.Command(dto));
            
            return NoContent();
        }
    }
}
