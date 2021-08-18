using Hitasp.HitCommerce.Core.Shared;
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

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    [Authorize(CorePermissions.StateOrProvinces.Default)]
    public class StateOrProvincesAppService : ApplicationService, IStateOrProvincesAppService
    {
        protected IStateOrProvinceRepository StateOrProvinceRepository { get; }
        protected IStateOrProvinceManager StateOrProvinceManager { get; }
        protected ICountryRepository CountryRepository { get; }

        public StateOrProvincesAppService(IStateOrProvinceRepository stateOrProvinceRepository,
            IStateOrProvinceManager stateOrProvinceManager,
            ICountryRepository countryRepository)
        {
            StateOrProvinceRepository = stateOrProvinceRepository;
            CountryRepository = countryRepository;
            StateOrProvinceManager = stateOrProvinceManager;
        }

        public virtual async Task<PagedResultDto<StateOrProvinceWithNavigationPropertiesDto>> GetListAsync(
            GetStateOrProvincesInput input)
        {
            var totalCount = await StateOrProvinceRepository.GetCountAsync(input.CountryId, input.FilterText,
                input.Name, input.Code3, input.Type);
            var items = await StateOrProvinceRepository.GetListWithNavigationPropertiesAsync(input.CountryId,
                input.FilterText, input.Name, input.Code3, input.Type, input.Sorting, input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<StateOrProvinceWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper
                    .Map<List<StateOrProvinceWithNavigationProperties>,
                        List<StateOrProvinceWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<StateOrProvinceWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<StateOrProvinceWithNavigationProperties, StateOrProvinceWithNavigationPropertiesDto>
                (await StateOrProvinceRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<StateOrProvinceDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StateOrProvince, StateOrProvinceDto>(await StateOrProvinceRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            var query = CountryRepository.AsQueryable()
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

        [Authorize(CorePermissions.StateOrProvinces.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await StateOrProvinceRepository.DeleteAsync(id);
        }

        [Authorize(CorePermissions.StateOrProvinces.Create)]
        public virtual async Task<StateOrProvinceDto> CreateAsync(StateOrProvinceCreateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var stateOrProvince = await StateOrProvinceManager.CreateAsync(input.CountryId,input.Name,input.Code3, input.Type);

            stateOrProvince = await StateOrProvinceRepository.InsertAsync(stateOrProvince, autoSave: true);
            return ObjectMapper.Map<StateOrProvince, StateOrProvinceDto>(stateOrProvince);
        }

        [Authorize(CorePermissions.StateOrProvinces.Edit)]
        public virtual async Task<StateOrProvinceDto> UpdateAsync(Guid id, StateOrProvinceUpdateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var stateOrProvince = await StateOrProvinceRepository.GetAsync(id);
            await StateOrProvinceManager.RenameAsync(stateOrProvince, input.Name);
            await StateOrProvinceManager.ChangeCodeAsync(stateOrProvince, input.Code3);
            stateOrProvince.Type = input.Type;

            return ObjectMapper.Map<StateOrProvince, StateOrProvinceDto>(await StateOrProvinceRepository.UpdateAsync(stateOrProvince, autoSave: true));
        }
    }
}