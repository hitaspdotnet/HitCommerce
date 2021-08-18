using Volo.Abp.Application.Dtos;
using System;

namespace Hitasp.HitCommerce.Core.Districts
{
    public class GetDistrictsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public Guid? CityId { get; set; }

        public GetDistrictsInput()
        {

        }
    }
}