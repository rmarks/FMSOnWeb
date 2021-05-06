using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared;
using FMS.Web.Shared.Dtos;
using FMS.Web.Shared.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            var query = _context.Products
                .AsNoTracking();

            return await query
                .OrderBy(p => p.Code)
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name
                })
                .GetPagedAsync(options.CurrentPage, options.PageSize);
        }
    }
}
