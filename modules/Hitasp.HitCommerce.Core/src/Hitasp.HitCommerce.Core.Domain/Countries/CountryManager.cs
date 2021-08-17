using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.Countries
{
    public class CountryManager : DomainService, ICountryManager
    {
        protected ICountryRepository CountryRepository { get; }

        public CountryManager(ICountryRepository countryRepository)
        {
            CountryRepository = countryRepository;
        }

        public virtual async Task<Country> CreateAsync(string name, string code3 = "", bool isBillingEnabled = false,
            bool isShippingEnabled = false)
        {
            await CheckCountryName(name);

            return new Country(GuidGenerator.Create(), name, code3, isBillingEnabled, isShippingEnabled);
        }

        public virtual async Task RenameAsync(Country country, string newName)
        {
            if (country.Name == newName)
            {
                return;
            }

            await CheckCountryName(newName);
            country.SetName(newName);
        }

        public virtual async Task ChangeCodeAsync(Country country, string newCode)
        {
            if (country.Code3 == newCode)
            {
                return;
            }

            await CheckCountryCode(newCode);
            country.SetCode3(newCode);
        }

        protected virtual async Task CheckCountryName(string name)
        {
            var country = await CountryRepository.FindByNameAsync(name);
            if (country != null)
            {
                throw new CountryAlreadyExistException(name);
            }
        }

        protected virtual async Task CheckCountryCode(string code)
        {
            var country = await CountryRepository.FindByCodeAsync(code);
            if (country != null)
            {
                throw new CountryAlreadyExistException(code);
            }
        }
    }
}