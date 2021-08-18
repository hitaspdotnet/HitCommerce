using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Hitasp.HitCommerce.Core.StateOrProvinces;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    [RemoteService(Name = "Core")]
    [Area("core")]
    [ControllerName("StateOrProvince")]
    [Route("api/core/state-or-provinces")]
    public class StateOrProvinceController : AbpController, IStateOrProvincesAppService
    {
        private readonly IStateOrProvincesAppService _stateOrProvincesAppService;

        public StateOrProvinceController(IStateOrProvincesAppService stateOrProvincesAppService)
        {
            _stateOrProvincesAppService = stateOrProvincesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<StateOrProvinceWithNavigationPropertiesDto>> GetListAsync(GetStateOrProvincesInput input)
        {
            return _stateOrProvincesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<StateOrProvinceWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _stateOrProvincesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StateOrProvinceDto> GetAsync(Guid id)
        {
            return _stateOrProvincesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("country-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _stateOrProvincesAppService.GetCountryLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<StateOrProvinceDto> CreateAsync(StateOrProvinceCreateDto input)
        {
            return _stateOrProvincesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StateOrProvinceDto> UpdateAsync(Guid id, StateOrProvinceUpdateDto input)
        {
            return _stateOrProvincesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _stateOrProvincesAppService.DeleteAsync(id);
        }
    }
}