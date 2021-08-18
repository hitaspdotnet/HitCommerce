using Hitasp.HitCommerce.Core.Shared;
using Hitasp.HitCommerce.Core.Cities;
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

namespace Hitasp.HitCommerce.Core.Districts
{
    [Authorize(CorePermissions.Districts.Default)]
    public class DistrictsAppService : ApplicationService, IDistrictsAppService
    {
        protected IDistrictRepository DistrictRepository { get; }
        protected IDistrictManager DistrictManager { get; }
        protected ICityRepository CityRepository { get; }

        public DistrictsAppService(IDistrictRepository districtRepository, IDistrictManager districtManager, ICityRepository cityRepository)
        {
            DistrictRepository = districtRepository;
            DistrictManager = districtManager;
            CityRepository = cityRepository;
        }

        public virtual async Task<PagedResultDto<DistrictWithNavigationPropertiesDto>> GetListAsync(
            GetDistrictsInput input)
        {
            var totalCount =
                await DistrictRepository.GetCountAsync(input.CityId, input.FilterText, input.Name, input.Type);
            var items = await DistrictRepository.GetListWithNavigationPropertiesAsync(input.CityId, input.FilterText,
                input.Name, input.Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<DistrictWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper
                    .Map<List<DistrictWithNavigationProperties>, List<DistrictWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<DistrictWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<DistrictWithNavigationProperties, DistrictWithNavigationPropertiesDto>
                (await DistrictRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<DistrictDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<District, DistrictDto>(await DistrictRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetCityLookupAsync(LookupRequestDto input)
        {
            var query = CityRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<City>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<City>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CorePermissions.Districts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await DistrictRepository.DeleteAsync(id);
        }

        [Authorize(CorePermissions.Districts.Create)]
        public virtual async Task<DistrictDto> CreateAsync(DistrictCreateDto input)
        {
            if (input.CityId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["City"]]);
            }

            var district = await DistrictManager.CreateAsync(input.CityId, input.Name, input.Type);

            return ObjectMapper.Map<District, DistrictDto>(await DistrictRepository.InsertAsync(district, autoSave: true));
        }

        [Authorize(CorePermissions.Districts.Edit)]
        public virtual async Task<DistrictDto> UpdateAsync(Guid id, DistrictUpdateDto input)
        {
            if (input.CityId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["City"]]);
            }

            var district = await DistrictRepository.GetAsync(id);
            await DistrictManager.RenameAsync(district, input.Name);
            district.Type = input.Type;
            
            return ObjectMapper.Map<District, DistrictDto>(await DistrictRepository.UpdateAsync(district, autoSave: true));
        }
    }
}