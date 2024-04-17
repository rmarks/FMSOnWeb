using FMS.Web.Shared.Features.ProductList;
using MediatR;
using System.Net.Http.Json;

namespace FMS.Web.Client.Features.ProductList
{
    public class GetProductsFilterDropdownsHandler : IRequestHandler<GetProductsFilterDropdownsRequest, GetProductsFilterDropdownsRequest.Response>
    {
        private readonly HttpClient _httpClient;

        public GetProductsFilterDropdownsHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetProductsFilterDropdownsRequest.Response> Handle(GetProductsFilterDropdownsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<GetProductsFilterDropdownsRequest.Response>(GetProductsFilterDropdownsRequest.RouteTemplate)
                    ?? new GetProductsFilterDropdownsRequest.Response(null);
            }
            catch (HttpRequestException)
            {
                return new GetProductsFilterDropdownsRequest.Response(null);
            }

        }
    }
}
