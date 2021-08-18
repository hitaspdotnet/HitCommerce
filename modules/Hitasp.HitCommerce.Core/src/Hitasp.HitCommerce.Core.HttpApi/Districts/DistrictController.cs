using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.Districts;

namespace Hitasp.HitCommerce.Core.Districts
{
    [RemoteService(Name = "Core")]
    [Area("core")]
    [ControllerName("District")]
    [Route("api/core/districts")]
    public class DistrictController : AbpController, IDistrictsAppService
    {
        private readonly IDistrictsAppService _districtsAppService;

        public DistrictController(IDistrictsAppService districtsAppService)
        {
            _districtsAppService = districtsAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<DistrictWithNavigationPropertiesDto>> GetListAsync(GetDistrictsInput input)
        {
            return _districtsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<DistrictWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _districtsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DistrictDto> GetAsync(Guid id)
        {
            return _districtsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("city-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetCityLookupAsync(LookupRequestDto input)
        {
            return _districtsAppService.GetCityLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<DistrictDto> CreateAsync(DistrictCreateDto input)
        {
            return _districtsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DistrictDto> UpdateAsync(Guid id, DistrictUpdateDto input)
        {
            return _districtsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _districtsAppService.DeleteAsync(id);
        }
    }
}