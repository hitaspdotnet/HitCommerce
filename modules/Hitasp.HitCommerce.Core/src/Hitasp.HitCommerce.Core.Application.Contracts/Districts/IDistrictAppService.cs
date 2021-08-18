using Hitasp.HitCommerce.Core.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Core.Districts
{
    public interface IDistrictsAppService : IApplicationService
    {
        Task<PagedResultDto<DistrictWithNavigationPropertiesDto>> GetListAsync(GetDistrictsInput input);

        Task<DistrictWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<DistrictDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetCityLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<DistrictDto> CreateAsync(DistrictCreateDto input);

        Task<DistrictDto> UpdateAsync(Guid id, DistrictUpdateDto input);
    }
}