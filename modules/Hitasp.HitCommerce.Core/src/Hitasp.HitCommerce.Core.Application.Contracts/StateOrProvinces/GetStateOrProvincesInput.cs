using Volo.Abp.Application.Dtos;
using System;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class GetStateOrProvincesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string Code3 { get; set; }
        public string Type { get; set; }
        public Guid? CountryId { get; set; }

        public GetStateOrProvincesInput()
        {

        }
    }
}