namespace FMS.Web.Shared.Features.Product
{
    public class ProductDtosProfile : AutoMapper.Profile
    {
        public ProductDtosProfile()
        {
            CreateMap<ProductBasicsDto, ProductBasicsDto>();
        }
    }
}
