using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.Cities
{
    public class CityManager : DomainService, ICityManager
    {
        protected ICityRepository CityRepository { get; }

        public CityManager(ICityRepository cityRepository)
        {
            CityRepository = cityRepository;
        }

        public virtual async Task<City> CreateAsync(Guid stateOrProvinceId,string name, string type)
        {
            await CheckCityName(stateOrProvinceId, name);

            return new City(GuidGenerator.Create(), stateOrProvinceId, name, type);
        }

        public virtual async Task RenameAsync(City city, string newName)
        {
            if (string.Equals(city.Name.Trim(), newName.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            await CheckCityName(city.StateOrProvinceId, newName);
            city.SetName(newName);
        }

        protected virtual async Task CheckCityName(Guid stateOrProvinceId, string name)
        {
            var city = await CityRepository.FindByNameAsync(stateOrProvinceId, name);
            if (city != null)
            {
                throw new CityNameAlreadyExistException(name);
            }
        }
    }
}