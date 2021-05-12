using System.ComponentModel.DataAnnotations;

namespace FMS.Web.Shared.Dtos
{
    public class ProductBaseDto
    {
        public int Id { get; set; }

        [Required, MaxLength(12)]
        public string Code { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public string Comments { get; set; }

        public int? ProductStatusId { get; set; }
        public int? ProductSourceTypeId { get; set; }
        public int? ProductDestinationTypeId { get; set; }
        public int? ProductMaterialId { get; set; }

        private int? _productTypeId;
        public int? ProductTypeId 
        { 
            get => _productTypeId;
            set
            {
                if (value != _productTypeId)
                {
                    ProductGroupId = default;
                    _productTypeId = value;
                }
            }
        }
        public int? ProductGroupId { get; set; }

        private int? _productBrandId;
        public int? ProductBrandId 
        { 
            get => _productBrandId;
            set
            {
                if (value != _productBrandId)
                {
                    ProductCollectionId = default;
                    _productBrandId = value;
                }
            }
        }
        public int? ProductCollectionId { get; set; }
        
        public int? ProductVariantTypeId { get; set; }

        //public IList<ProductDto> Products { get; set; }
    }
}
