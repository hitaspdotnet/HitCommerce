using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Core.Cities
{
    public interface ICitiesAppService : IApplicationService
    {
        Task<PagedResultDto<CityWithNavigationPropertiesDto>> GetListAsync(GetCitiesInput input);

        Task<CityWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<CityDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetStateOrProvinceLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<CityDto> CreateAsync(CityCreateDto input);

        Task<CityDto> UpdateAsync(Guid id, CityUpdateDto input);
    }
}