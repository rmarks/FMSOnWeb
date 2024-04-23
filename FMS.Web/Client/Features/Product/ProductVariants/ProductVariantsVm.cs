namespace FMS.Web.Client.Features.Product.ProductVariants;

public class ProductVariantsVm
{
    public int Id { get; set; }
    public int? ProductVariantTypeId { get; set; }
    public IList<ProductVm> Products { get; set; } = default!;

    public class ProductVm
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ProductBaseId { get; set; }
    }
}
