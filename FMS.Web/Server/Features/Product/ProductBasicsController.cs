using FMS.Application.Features.Product.ProductBasics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductBasicsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
