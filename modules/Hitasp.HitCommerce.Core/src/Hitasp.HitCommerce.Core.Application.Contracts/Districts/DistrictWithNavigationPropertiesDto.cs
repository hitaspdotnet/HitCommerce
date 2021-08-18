using Hitasp.HitCommerce.Core.Cities;

using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Core.Districts
{
    public class DistrictWithNavigationPropertiesDto
    {
        public DistrictDto District { get; set; }

        public CityDto City { get; set; }

    }
}