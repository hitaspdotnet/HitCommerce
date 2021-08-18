using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public interface IStateOrProvincesAppService : IApplicationService
    {
        Task<PagedResultDto<StateOrProvinceWithNavigationPropertiesDto>> GetListAsync(GetStateOrProvincesInput input);

        Task<StateOrProvinceWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<StateOrProvinceDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<StateOrProvinceDto> CreateAsync(StateOrProvinceCreateDto input);

        Task<StateOrProvinceDto> UpdateAsync(Guid id, StateOrProvinceUpdateDto input);
    }
}