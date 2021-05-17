using FMS.Web.Shared.Features.LocationList;

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
    }
}
