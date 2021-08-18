using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.Districts
{
    public class DistrictManager : DomainService, IDistrictManager
    {
        protected IDistrictRepository DistrictRepository { get; }

        public DistrictManager(IDistrictRepository districtRepository)
        {
            DistrictRepository = districtRepository;
        }

        public virtual async Task<District> CreateAsync(Guid cityId,string name, string type)
        {
            await CheckDistrictName(cityId, name);

            return new District(GuidGenerator.Create(), cityId, name, type);
        }

        public virtual async Task RenameAsync(District district, string newName)
        {
            if (string.Equals(district.Name.Trim(), newName.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            await CheckDistrictName(district.CityId, newName);
            district.SetName(newName);
        }

        protected virtual async Task CheckDistrictName(Guid cityId, string name)
        {
            var district = await DistrictRepository.FindByNameAsync(cityId, name);
            if (district != null)
            {
                throw new DistrictNameAlreadyExistException(name);
            }
        }
    }
}