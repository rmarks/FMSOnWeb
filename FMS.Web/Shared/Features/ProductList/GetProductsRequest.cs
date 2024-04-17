using FMS.Web.Shared.Features.Shared;
using MediatR;

namespace FMS.Web.Shared.Features.ProductList
{
    public record GetProductsRequest(ProductListFilterVm Filter) : IRequest<GetProductsRequest.Response>
    {
        public const string RouteTemplate = "api/products";

        public record Response(PagedResult<ProductListItemVm> PagedProducts);
    }
}
