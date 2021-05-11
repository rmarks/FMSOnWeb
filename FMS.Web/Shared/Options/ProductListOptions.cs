namespace FMS.Web.Shared.Options
{
    public record ProductListOptions : PagedOptionsBase
    {
        public int ProductStatusId { get; set; }
        public int ProductMaterialId { get; set; }
        public int ProductSourceTypeId { get; set; }
        public int ProductDestinationTypeId { get; set; }

        private int _productTypeId;
        public int ProductTypeId
        {
            get => _productTypeId;
            set
            {
                if (value != _productTypeId)
                {
                    ProductGroupId = 0;
                    _productTypeId = value;
                }
            }
        }

        public int ProductGroupId { get; set; }

        private int _productBrandId;
        public int ProductBrandId
        {
            get => _productBrandId;
            set
            {
                if (value != _productBrandId)
                {
                    ProductCollectionId = 0;
                    _productBrandId = value;
                }
            }
        }

        public int ProductCollectionId { get; set; }
    }
}
