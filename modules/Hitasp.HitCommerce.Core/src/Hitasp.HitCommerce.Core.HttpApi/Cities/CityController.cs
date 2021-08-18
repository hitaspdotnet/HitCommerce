using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.Cities;

namespace Hitasp.HitCommerce.Core.Cities
{
    [RemoteService(Name = "Core")]
    [Area("core")]
    [ControllerName("City")]
    [Route("api/core/cities")]
    public class CityController : AbpController, ICitiesAppService
    {
        private readonly ICitiesAppService _citiesAppService;

        public CityController(ICitiesAppService citiesAppService)
        {
            _citiesAppService = citiesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<CityWithNavigationPropertiesDto>> GetListAsync(GetCitiesInput input)
        {
            return _citiesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<CityWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _citiesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CityDto> GetAsync(Guid id)
        {
            return _citiesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("state-or-province-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetStateOrProvinceLookupAsync(LookupRequestDto input)
        {
            return _citiesAppService.GetStateOrProvinceLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<CityDto> CreateAsync(CityCreateDto input)
        {
            return _citiesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CityDto> UpdateAsync(Guid id, CityUpdateDto input)
        {
            return _citiesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _citiesAppService.DeleteAsync(id);
        }
    }
}