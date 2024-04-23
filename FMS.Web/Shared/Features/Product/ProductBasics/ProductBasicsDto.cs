namespace FMS.Web.Shared.Features.Product.ProductBasics;

public record ProductBasicsDto(
    int Id,
    string Code,
    string Name,
    string Comments,
    int? ProductStatusId,
    int? ProductSourceTypeId,
    int? ProductDestinationTypeId,
    int? ProductMaterialId,
    int? ProductTypeId,
    int? ProductGroupId,
    int? ProductBrandId,
    int? ProductCollectionId);
