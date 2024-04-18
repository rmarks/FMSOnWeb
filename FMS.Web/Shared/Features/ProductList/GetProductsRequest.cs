using FMS.Web.Shared.Features.Shared.Paged;
using FMS.Web.Shared.Features.Shared.ProductFilter;
using MediatR;

namespace FMS.Web.Shared.Features.ProductList
{
    public record GetProductsRequest(ProductFilterVm Filter) : IRequest<GetProductsRequest.Response>
    {
        public const string RouteTemplate = "api/products";

        public record Response(PagedResult<ProductListItemVm> PagedProducts);
    }
}
