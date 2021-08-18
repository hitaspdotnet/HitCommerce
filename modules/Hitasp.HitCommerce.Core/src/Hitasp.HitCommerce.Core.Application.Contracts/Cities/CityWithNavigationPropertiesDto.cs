using Hitasp.HitCommerce.Core.StateOrProvinces;

using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.Cities
{
    public class CityWithNavigationPropertiesDto
    {
        public CityDto City { get; set; }

        public StateOrProvinceDto StateOrProvince { get; set; }

    }
}