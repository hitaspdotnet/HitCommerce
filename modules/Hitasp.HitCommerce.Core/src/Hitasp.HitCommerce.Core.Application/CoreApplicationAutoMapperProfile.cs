using System;
using Hitasp.HitCommerce.Core.Shared;
using Volo.Abp.AutoMapper;
using Hitasp.HitCommerce.Core.Countries;
using AutoMapper;

namespace Hitasp.HitCommerce.Core
{
    public class CoreApplicationAutoMapperProfile : Profile
    {
        public CoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<CountryCreateDto, Country>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<CountryUpdateDto, Country>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<Country, CountryDto>();
        }
    }
}