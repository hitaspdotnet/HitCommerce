using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Core.Permissions;

namespace Hitasp.HitCommerce.Core.Countries
{

    [Authorize(CorePermissions.Countries.Default)]
    public class CountriesAppService : ApplicationService, ICountriesAppService
    {
        protected ICountryRepository CountryRepository { get; }
        protected ICountryManager CountryManager { get; }

        public CountriesAppService(ICountryRepository countryRepository, ICountryManager countryManager)
        {
            CountryRepository = countryRepository;
            CountryManager = countryManager;
        }

        public virtual async Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            var totalCount = await CountryRepository.GetCountAsync(input.FilterText, input.Name, input.Code3, input.IsBillingEnabled, input.IsShippingEnabled);
            var items = await CountryRepository.GetListAsync(input.FilterText, input.Name, input.Code3, input.IsBillingEnabled, input.IsShippingEnabled, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CountryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<CountryDto>>(items)
            };
        }

        public virtual async Task<CountryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Country, CountryDto>(await CountryRepository.GetAsync(id));
        }

        [Authorize(CorePermissions.Countries.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await CountryRepository.DeleteAsync(id);
        }

        [Authorize(CorePermissions.Countries.Create)]
        public virtual async Task<CountryDto> CreateAsync(CountryCreateDto input)
        {
            var country = await CountryManager.CreateAsync(input.Name, input.Code3, input.IsBillingEnabled, input.IsShippingEnabled);
            country = await CountryRepository.InsertAsync(country, autoSave: true);

            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        [Authorize(CorePermissions.Countries.Edit)]
        public virtual async Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input)
        {
            var country = await CountryRepository.GetAsync(id);
            await CountryManager.RenameAsync(country, input.Name);
            await CountryManager.ChangeCodeAsync(country, input.Code3);
            country.IsBillingEnabled = input.IsBillingEnabled;
            country.IsShippingEnabled = input.IsShippingEnabled;

            return ObjectMapper.Map<Country, CountryDto>(await CountryRepository.UpdateAsync(country, autoSave: true));
        }
    }
}