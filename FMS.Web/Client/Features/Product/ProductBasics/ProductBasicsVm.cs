using FluentValidation;

namespace FMS.Web.Client.Features.Product.ProductBasics;

public record ProductBasicsVm
{
    public int Id { get; set; }

    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Comments { get; set; } = "";

    public int ProductStatusId { get; set; }
    public int ProductSourceTypeId { get; set; }
    public int ProductDestinationTypeId { get; set; }
    public int ProductMaterialId { get; set; }
    public int ProductTypeId { get; set; }
    public int ProductGroupId { get; set; }
    public int ProductBrandId { get; set; }
    public int ProductCollectionId { get; set; }
}

public class ProductBasicsValidator : AbstractValidator<ProductBasicsVm>
{
    public ProductBasicsValidator()
    {
        RuleFor(p => p.Code).NotEmpty().WithMessage("Sisesta kood")
                            .MaximumLength(12).WithMessage("Liiga pikk (max 12)");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Sisesta nimetus")
                            .MaximumLength(50).WithMessage("Liiga pikk (max 50)");
        RuleFor(p => p.ProductStatusId).NotEmpty().WithMessage("Sisesta olek");
        RuleFor(p => p.ProductSourceTypeId).NotEmpty().WithMessage("Sisesta lähtetüüp");
        RuleFor(p => p.ProductDestinationTypeId).NotEmpty().WithMessage("Sisesta sihttüüp");
        RuleFor(p => p.ProductMaterialId).NotEmpty().WithMessage("Sisesta materjal");
        RuleFor(p => p.ProductTypeId).NotEmpty().WithMessage("Sisesta tüüp");
        RuleFor(p => p.ProductGroupId).NotEmpty().WithMessage("Sisesta grupp");
    }
}
