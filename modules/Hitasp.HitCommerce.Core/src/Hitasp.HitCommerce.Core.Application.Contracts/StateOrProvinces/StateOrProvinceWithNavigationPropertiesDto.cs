using Hitasp.HitCommerce.Core.Countries;

using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class StateOrProvinceWithNavigationPropertiesDto
    {
        public StateOrProvinceDto StateOrProvince { get; set; }

        public CountryDto Country { get; set; }

    }
}