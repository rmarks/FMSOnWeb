using FMS.DAL;
using FMS.ServiceLayer.ProductServices;
using FMS.Web.Shared;
using FMS.Web.Shared.Dropdowns;
using FMS.Web.Shared.Dtos;
using FMS.Web.Shared.Options;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FMS.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly FMSContext _context;

        public ProductsController(FMSContext context)
        {
            _context = context;
        }

        //POST: api/products
        [HttpPost]
        public async Task<ActionResult<PagedResult<ProductListDto>>> GetProductList(ProductListOptions options)
        {
            var service = new ProductsService(_context);

            return await service.GetProductList(options);
        }

        //GET: api/products/dropdowns
        [HttpGet("dropdowns")]
        public async Task<ActionResult<ProductFilterDropdowns>> GetProductFilterDropdowns()
        {
            var service = new ProductDropdownsService(_context);

            return await service.GetProductFilterDropdowns();
        }
    }
}
