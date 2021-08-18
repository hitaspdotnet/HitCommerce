using Volo.Abp.Application.Dtos;
using System;

namespace Hitasp.HitCommerce.Core.Cities
{
    public class GetCitiesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public Guid? StateOrProvinceId { get; set; }

        public GetCitiesInput()
        {

        }
    }
}