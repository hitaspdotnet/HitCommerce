using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Countries;
using AutoMapper;

namespace Hitasp.HitCommerce.Core.Web
{
    public class CoreWebAutoMapperProfile : Profile
    {
        public CoreWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<CountryDto, CountryUpdateDto>();

            CreateMap<StateOrProvinceDto, StateOrProvinceUpdateDto>();

            CreateMap<CityDto, CityUpdateDto>();
        }
    }
}