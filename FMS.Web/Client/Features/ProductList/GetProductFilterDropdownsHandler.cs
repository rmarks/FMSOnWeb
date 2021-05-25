using FMS.Web.Shared.Features.ProductList;
using MediatR;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Client.Features.ProductList
{
    public class GetProductFilterDropdownsHandler : IRequestHandler<GetProductFilterDropdownsRequest, GetProductFilterDropdownsRequest.Response>
    {
        private readonly HttpClient _http;

        public GetProductFilterDropdownsHandler(HttpClient http)
        {
            _http = http;
        }

        public async Task<GetProductFilterDropdownsRequest.Response> Handle(GetProductFilterDropdownsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _http.GetFromJsonAsync<GetProductFilterDropdownsRequest.Response>(GetProductFilterDropdownsRequest.RouteTemplate);

            }
            catch (HttpRequestException)
            {
                return new GetProductFilterDropdownsRequest.Response(null);
            }

        }
    }
}
