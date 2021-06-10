using FMS.Domain.Models;
using FMS.Web.Shared.Features.Product;

namespace FMS.Application.Features.Product
{
    public class ProductDtosProfile : AutoMapper.Profile
    {
        public ProductDtosProfile()
        {
            CreateMap<ProductBase, ProductBasicsDto>().ReverseMap();
        }
    }
}
