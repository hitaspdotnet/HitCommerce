using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Hitasp.HitCommerce.Core.Permissions;
using Hitasp.HitCommerce.Core.Countries;

namespace Hitasp.HitCommerce.Core.Countries
{

    [Authorize(CorePermissions.Countries.Default)]
    public class CountriesAppService : ApplicationService, ICountriesAppService
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesAppService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public virtual async Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            var totalCount = await _countryRepository.GetCountAsync(input.FilterText, input.Name, input.Code3, input.IsBillingEnabled, input.IsShippingEnabled);
            var items = await _countryRepository.GetListAsync(input.FilterText, input.Name, input.Code3, input.IsBillingEnabled, input.IsShippingEnabled, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CountryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<CountryDto>>(items)
            };
        }

        public virtual async Task<CountryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Country, CountryDto>(await _countryRepository.GetAsync(id));
        }

        [Authorize(CorePermissions.Countries.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        [Authorize(CorePermissions.Countries.Create)]
        public virtual async Task<CountryDto> CreateAsync(CountryCreateDto input)
        {

            var country = ObjectMapper.Map<CountryCreateDto, Country>(input);

            country = await _countryRepository.InsertAsync(country, autoSave: true);
            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        [Authorize(CorePermissions.Countries.Edit)]
        public virtual async Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input)
        {

            var country = await _countryRepository.GetAsync(id);
            ObjectMapper.Map(input, country);
            country = await _countryRepository.UpdateAsync(country, autoSave: true);
            return ObjectMapper.Map<Country, CountryDto>(country);
        }
    }
}