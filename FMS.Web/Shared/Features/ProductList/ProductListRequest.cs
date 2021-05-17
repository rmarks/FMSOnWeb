using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.ProductList
{
    public record ProductListRequest(ProductFilterOptions Options)
    {
        public record Response(PagedResult<ProductListDto> PagedProducts);
    }
}
