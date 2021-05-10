using FMS.DAL;
using FMS.ServiceLayer.Extensions;
using FMS.Web.Shared;
using FMS.Web.Shared.Dtos;
using FMS.Web.Shared.Options;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.ProductServices
{
    public class ProductsService
    {
        private readonly FMSContext _context;

        public ProductsService(FMSContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductListDto>> GetProductList(ProductListOptions options)
        {
            var query = _context.ProductBases
                .AsNoTracking();

            if (options.ProductStatusId > 0)
            {
                query = query.Where(p => p.ProductStatusId == options.ProductStatusId);
            };

            if (options.ProductMaterialId > 0)
            {
                query = query.Where(p => p.ProductMaterialId == options.ProductMaterialId);
            };

            if (options.ProductSourceTypeId > 0)
            {
                query = query.Where(p => p.ProductSourceTypeId == options.ProductSourceTypeId);
            };

            if (options.ProductDestinationTypeId > 0)
            {
                query = query.Where(p => p.ProductDestinationTypeId == options.ProductDestinationTypeId);
            };

            if (options.ProductGroupId > 0)
            {
                query = query.Where(p => p.ProductGroupId == options.ProductGroupId);
            }
            else if (options.ProductTypeId > 0)
            {
                query = query.Where(p => p.ProductTypeId == options.ProductTypeId);
            };

            if (options.ProductCollectionId > 0)
            {
                query = query.Where(p => p.ProductCollectionId == options.ProductCollectionId);
            }
            else if (options.ProductBrandId > 0)
            {
                query = query.Where(p => p.ProductBrandId == options.ProductBrandId);
            };

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
