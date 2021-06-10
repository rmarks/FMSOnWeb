using FluentValidation;

namespace FMS.Web.Shared.Features.Product
{
    public class ProductBasicsDto
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }

        public int? ProductStatusId { get; set; }
        public int? ProductSourceTypeId { get; set; }
        public int? ProductDestinationTypeId { get; set; }
        public int? ProductMaterialId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? ProductBrandId { get; set; }
        public int? ProductCollectionId { get; set; }
    }

    public class ProductBasicsValidator : AbstractValidator<ProductBasicsDto>
    {
        public ProductBasicsValidator()
        {
            RuleFor(_ => _.Code).NotEmpty().WithMessage("Sisesta kood")
                                .MaximumLength(12).WithMessage("Liiga pikk (max 12)");
            RuleFor(_ => _.Name).NotEmpty().WithMessage("Sisesta nimetus")
                                .MaximumLength(50).WithMessage("Liiga pikk (max 50)");
            RuleFor(_ => _.ProductStatusId).NotEmpty().WithMessage("Sisesta olek");
            RuleFor(_ => _.ProductSourceTypeId).NotEmpty().WithMessage("Sisesta lähtetüüp");
            RuleFor(_ => _.ProductDestinationTypeId).NotEmpty().WithMessage("Sisesta sihttüüp");
            RuleFor(_ => _.ProductMaterialId).NotEmpty().WithMessage("Sisesta materjal");
            RuleFor(_ => _.ProductTypeId).NotEmpty().WithMessage("Sisesta tüüp");
            RuleFor(_ => _.ProductGroupId).NotEmpty().WithMessage("Sisesta grupp");
        }
    }
}
