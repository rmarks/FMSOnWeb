using FMS.Web.Shared.Features.LocationList;
using FMS.Web.Shared.Features.ProductList;

namespace FMS.Web.Client.Features.Shared
{
    public class AppStateManager
    {
        private LocationFilterOptions _locationListOptions;
        public LocationFilterOptions LocationListOptions 
        {
            get
            {
                var temp = _locationListOptions;
                _locationListOptions = null;

                return temp;
            }
            set => _locationListOptions = value; 
        }

        private ProductFilterOptionsVm _productFilterOptions;
        public ProductFilterOptionsVm ProductFilterOptions 
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
