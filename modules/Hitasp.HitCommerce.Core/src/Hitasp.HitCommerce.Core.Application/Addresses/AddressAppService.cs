using Hitasp.HitCommerce.Core.Shared;
using Hitasp.HitCommerce.Core.Districts;
using Hitasp.HitCommerce.Core.Cities;
using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Countries;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Core.Permissions;

namespace Hitasp.HitCommerce.Core.Addresses
{
    [Authorize(CorePermissions.Addresses.Default)]
    public class AddressesAppService : ApplicationService, IAddressesAppService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateOrProvinceRepository _stateOrProvinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;

        public AddressesAppService(IAddressRepository addressRepository, ICountryRepository countryRepository,
            IStateOrProvinceRepository stateOrProvinceRepository, ICityRepository cityRepository,
            IDistrictRepository districtRepository)
        {
            _addressRepository = addressRepository;
            _countryRepository = countryRepository;
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
        }

        public virtual async Task<PagedResultDto<AddressWithNavigationPropertiesDto>> GetListAsync(
            GetAddressesInput input)
        {
            var totalCount = await _addressRepository.GetCountAsync(input.FilterText, input.ContactName, input.Phone,
                input.AddressLine1, input.AddressLine2, input.ZipOrPostalCode, input.CountryId, input.StateOrProvinceId,
                input.CityId, input.DistrictId);
            var items = await _addressRepository.GetListWithNavigationPropertiesAsync(input.FilterText,
                input.ContactName, input.Phone, input.AddressLine1, input.AddressLine2, input.ZipOrPostalCode,
                input.CountryId, input.StateOrProvinceId, input.CityId, input.DistrictId, input.Sorting,
                input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AddressWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper
                    .Map<List<AddressWithNavigationProperties>, List<AddressWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<AddressWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<AddressWithNavigationProperties, AddressWithNavigationPropertiesDto>
                (await _addressRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<AddressDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Address, AddressDto>(await _addressRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            var query = _countryRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Country>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetStateOrProvinceLookupAsync(Guid countryId, LookupRequestDto input)
        {
            var query = _stateOrProvinceRepository.AsQueryable()
                .Where(x => x.CountryId == countryId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount)
                .ToDynamicListAsync<StateOrProvince>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<StateOrProvince>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid?>>> GetCityLookupAsync(Guid stateOrProvinceId, LookupRequestDto input)
        {
            var query = _cityRepository.AsQueryable()
                .Where(x => x.StateOrProvinceId == stateOrProvinceId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<City>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid?>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<City>, List<LookupDto<Guid?>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid?>>> GetDistrictLookupAsync(Guid cityId, LookupRequestDto input)
        {
            var query = _districtRepository.AsQueryable()
                .Where(x => x.CityId == cityId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<District>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid?>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<District>, List<LookupDto<Guid?>>>(lookupData)
            };
        }

        [Authorize(CorePermissions.Addresses.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _addressRepository.DeleteAsync(id);
        }

        [Authorize(CorePermissions.Addresses.Create)]
        public virtual async Task<AddressDto> CreateAsync(AddressCreateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            if (input.StateOrProvinceId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["StateOrProvince"]]);
            }

            var address = ObjectMapper.Map<AddressCreateDto, Address>(input);

            address = await _addressRepository.InsertAsync(address, autoSave: true);
            return ObjectMapper.Map<Address, AddressDto>(address);
        }

        [Authorize(CorePermissions.Addresses.Edit)]
        public virtual async Task<AddressDto> UpdateAsync(Guid id, AddressUpdateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            if (input.StateOrProvinceId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["StateOrProvince"]]);
            }

            var address = await _addressRepository.GetAsync(id);
            ObjectMapper.Map(input, address);
            address = await _addressRepository.UpdateAsync(address, autoSave: true);
            return ObjectMapper.Map<Address, AddressDto>(address);
        }
    }
}