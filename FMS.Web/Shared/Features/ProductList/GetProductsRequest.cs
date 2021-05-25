using FMS.Web.Shared.Features.Shared;
using MediatR;

namespace FMS.Web.Shared.Features.ProductList
{
    public record GetProductsRequest(ProductFilterOptionsVm Options) : IRequest<GetProductsRequest.Response>
    {
        public const string RouteTemplate = "api/products";

        public record Response(PagedResult<ProductLisItemVm> PagedProducts);
    }
}
