using Hitasp.HitCommerce.Core.Shared;
using Hitasp.HitCommerce.Core.StateOrProvinces;
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
using Hitasp.HitCommerce.Core.Cities;

namespace Hitasp.HitCommerce.Core.Cities
{

    [Authorize(CorePermissions.Cities.Default)]
    public class CitiesAppService : ApplicationService, ICitiesAppService
    {
        protected ICityRepository CityRepository { get; }
        protected ICityManager CityManager { get; }
        protected IStateOrProvinceRepository StateOrProvinceRepository { get; }

        public CitiesAppService(ICityRepository cityRepository, ICityManager cityManager, IStateOrProvinceRepository stateOrProvinceRepository)
        {
            CityRepository = cityRepository;
            CityManager = cityManager;
            StateOrProvinceRepository = stateOrProvinceRepository;
        }

        public virtual async Task<PagedResultDto<CityWithNavigationPropertiesDto>> GetListAsync(GetCitiesInput input)
        {
            var totalCount = await CityRepository.GetCountAsync(input.StateOrProvinceId, input.FilterText, input.Name, input.Type);
            var items = await CityRepository.GetListWithNavigationPropertiesAsync(input.StateOrProvinceId, input.FilterText, input.Name, input.Type,  input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CityWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CityWithNavigationProperties>, List<CityWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<CityWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<CityWithNavigationProperties, CityWithNavigationPropertiesDto>
                (await CityRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<CityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<City, CityDto>(await CityRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetStateOrProvinceLookupAsync(LookupRequestDto input)
        {
            var query = StateOrProvinceRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<StateOrProvince>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<StateOrProvince>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CorePermissions.Cities.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await CityRepository.DeleteAsync(id);
        }

        [Authorize(CorePermissions.Cities.Create)]
        public virtual async Task<CityDto> CreateAsync(CityCreateDto input)
        {
            if (input.StateOrProvinceId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["StateOrProvince"]]);
            }

            var city = await CityManager.CreateAsync(input.StateOrProvinceId, input.Name, input.Type);

            return ObjectMapper.Map<City, CityDto>(await CityRepository.InsertAsync(city, autoSave: true));
        }

        [Authorize(CorePermissions.Cities.Edit)]
        public virtual async Task<CityDto> UpdateAsync(Guid id, CityUpdateDto input)
        {
            if (input.StateOrProvinceId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["StateOrProvince"]]);
            }

            var city = await CityRepository.GetAsync(id);

            await CityManager.RenameAsync(city, input.Name);
            city.Type = input.Type;
            
            return ObjectMapper.Map<City, CityDto>(await CityRepository.UpdateAsync(city));
        }
    }
}