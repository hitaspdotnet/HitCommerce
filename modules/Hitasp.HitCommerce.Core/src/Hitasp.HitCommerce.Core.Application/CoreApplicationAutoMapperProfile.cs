using Hitasp.HitCommerce.Core.Addresses;
using Hitasp.HitCommerce.Core.Districts;
using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.StateOrProvinces;
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
            CreateMap<Country, LookupDto<Guid>>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<StateOrProvinceCreateDto, StateOrProvince>().IgnoreFullAuditedObjectProperties()
                .Ignore(x => x.Id);
            CreateMap<StateOrProvinceUpdateDto, StateOrProvince>().IgnoreFullAuditedObjectProperties()
                .Ignore(x => x.Id);
            CreateMap<StateOrProvince, StateOrProvinceDto>();
            CreateMap<StateOrProvinceWithNavigationProperties, StateOrProvinceWithNavigationPropertiesDto>();

            CreateMap<CityCreateDto, City>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<CityUpdateDto, City>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<City, CityDto>();
            CreateMap<CityWithNavigationProperties, CityWithNavigationPropertiesDto>();
            CreateMap<StateOrProvince, LookupDto<Guid>>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<DistrictCreateDto, District>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<DistrictUpdateDto, District>().IgnoreFullAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<District, DistrictDto>();
            CreateMap<DistrictWithNavigationProperties, DistrictWithNavigationPropertiesDto>();
            CreateMap<City, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

            CreateMap<AddressCreateDto, Address>().IgnoreAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<AddressUpdateDto, Address>().IgnoreAuditedObjectProperties().Ignore(x => x.Id);
            CreateMap<Address, AddressDto>();

            CreateMap<AddressWithNavigationProperties, AddressWithNavigationPropertiesDto>();
            CreateMap<City, LookupDto<Guid?>>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
            CreateMap<District, LookupDto<Guid?>>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
        }
    }
}