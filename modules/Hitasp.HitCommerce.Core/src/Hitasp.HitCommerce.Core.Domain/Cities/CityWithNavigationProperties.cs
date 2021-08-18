using Hitasp.HitCommerce.Core.StateOrProvinces;

namespace Hitasp.HitCommerce.Core.Cities
{
    public class CityWithNavigationProperties
    {
        public City City { get; set; }

        public StateOrProvince StateOrProvince { get; set; }
        
    }
}