using FMS.Web.Shared.Features.Product;
using MediatR;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Client.Features.Product
{
    public class GetProductBasicsHandler : IRequestHandler<GetProductBasicsRequest, GetProductBasicsRequest.Response>
    {
        private readonly HttpClient _http;

        public GetProductBasicsHandler(HttpClient http)
        {
            _http = http;
        }

        public async Task<GetProductBasicsRequest.Response> Handle(GetProductBasicsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _http.GetFromJsonAsync<GetProductBasicsRequest.Response>(GetProductBasicsRequest.RouteTemplate.Replace("{id}", request.Id.ToString()));
            }
            catch (HttpRequestException)
            {
                return new GetProductBasicsRequest.Response(null);
            }
        }
    }
}
