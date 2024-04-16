using FMS.Web.Shared.Features.LocationList;
using FMS.Web.Shared.Features.ProductList;

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

        private ProductFilterOptionsVm? _productFilterOptions;
        public ProductFilterOptionsVm? ProductFilterOptions 
        {
            get
            {
                var temp = _productFilterOptions;
                _productFilterOptions = null;

                return temp;
            }
            set => _productFilterOptions = value; 
        }
    }
}
