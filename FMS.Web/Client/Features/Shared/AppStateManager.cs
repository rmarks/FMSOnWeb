using FMS.Web.Shared.Features.LocationList;

namespace FMS.Web.Client.Features.Shared
{
    public class AppStateManager
    {
        private LocationListOptions _locationListOptions;
        public LocationListOptions LocationListOptions 
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
