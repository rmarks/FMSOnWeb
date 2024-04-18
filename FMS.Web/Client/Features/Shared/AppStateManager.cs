using FMS.Web.Shared.Features.LocationList;
using FMS.Web.Shared.Features.Shared.ProductFilter;

namespace FMS.Web.Client.Features.Shared
{
    public class AppStateManager
    {
        private LocationFilterVm? _locationListFilter;
        public LocationFilterVm? LocationListFilter 
        {
            get
            {
                var temp = _locationListFilter;
                _locationListFilter = null;

                return temp;
            }
            set => _locationListFilter = value; 
        }

        private ProductFilterVm? _productListFilter;
        public ProductFilterVm? ProductListFilter 
        {
            get
            {
                var temp = _productListFilter;
                _productListFilter = null;

                return temp;
            }
            set => _productListFilter = value; 
        }
    }
}
