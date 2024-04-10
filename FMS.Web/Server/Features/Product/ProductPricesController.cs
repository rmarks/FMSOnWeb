using FMS.Application.Features.Product.ProductPrices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Web.Server.Features.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPricesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductPricesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductPricesController>/dropdowns
        [HttpGet("dropdowns")]
        public async Task<IActionResult> Get()
        {
            var dto = await _mediator.Send(new GetProductPricesDropdowns.Query());
            return dto == null ? NotFound() : Ok(dto);
        }

        // GET api/<ProductPricesController>/productbase/5/pricelist/3
        [HttpGet("productbase/{productBaseId}/pricelist/{priceListId}")]
        public async Task<IActionResult> Get(int productBaseId, int priceListId)
        {
            var prices = await _mediator.Send(new GetProductPrices.Query(productBaseId, priceListId));
            return prices == null ? NotFound() : Ok(prices);
        }

        // POST api/<ProductPricesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductPricesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductPricesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
