using Hitasp.HitCommerce.Core.Countries;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class StateOrProvinceWithNavigationProperties
    {
        public StateOrProvince StateOrProvince { get; set; }

        public Country Country { get; set; }
        
    }
}