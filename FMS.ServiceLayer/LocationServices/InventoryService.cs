using FMS.DAL;
using FMS.ServiceLayer.Extensions;
using FMS.Web.Shared.Features.LocationInventoryList;
using FMS.Web.Shared.Features.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.LocationServices
{
    public class InventoryService
    {
        private readonly FMSContext _context;

        public InventoryService(FMSContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<LocationInventoryListDto>> GetLocationInventory(int locationId, LocationInventoryListOptions options)
        {
            var query = _context.Inventory
                .AsNoTracking()
                .Where(i => i.LocationId == locationId);

            if (options.ProductStatusId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductStatusId == options.ProductStatusId);
            };

            if (options.ProductMaterialId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductMaterialId == options.ProductMaterialId);
            };

            if (options.ProductSourceTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductSourceTypeId == options.ProductSourceTypeId);
            };

            if (options.ProductDestinationTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductDestinationTypeId == options.ProductDestinationTypeId);
            };

            if (options.ProductGroupId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductGroupId == options.ProductGroupId);
            }
            else if (options.ProductTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductTypeId == options.ProductTypeId);
            };

            if (options.ProductCollectionId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductCollectionId == options.ProductCollectionId);
            }
            else if (options.ProductBrandId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductBrandId == options.ProductBrandId);
            };

            return await query
                .GroupBy(i => new { i.Product.ProductBase.Id, i.Product.ProductBase.Code, i.Product.ProductBase.Name, i.LocationId } ,
                         i => i, 
                         (key, g) => new LocationInventoryListDto
                         {
                            ProductBaseId = key.Id,
                            ProductBaseCode = key.Code,
                            ProductBaseName = key.Name,
                            LocationId = key.LocationId,
                            StockQuantity = g.Sum(i => i.StockQuantity),
                            ReservedQuantity = g.Sum(i => i.ReservedQuantity)
                         })
                .OrderBy(l => l.ProductBaseCode)
                .GetPagedAsync(options.CurrentPage, options.PageSize);
        }
    }
}
