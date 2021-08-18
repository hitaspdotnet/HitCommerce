using Hitasp.HitCommerce.Core.Countries;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.Districts;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public class AddressWithNavigationProperties
    {
        public Address Address { get; set; }

        public Country Country { get; set; }
        public StateOrProvince StateOrProvince { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        
    }
}