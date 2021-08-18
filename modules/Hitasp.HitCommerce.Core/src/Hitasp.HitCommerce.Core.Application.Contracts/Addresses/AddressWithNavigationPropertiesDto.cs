using Hitasp.HitCommerce.Core.Countries;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.Districts;

using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public class AddressWithNavigationPropertiesDto
    {
        public AddressDto Address { get; set; }

        public CountryDto Country { get; set; }
        public StateOrProvinceDto StateOrProvince { get; set; }
        public CityDto City { get; set; }
        public DistrictDto District { get; set; }

    }
}