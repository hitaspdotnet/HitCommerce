using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.Core.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Core.Addresses
{
    public class EfCoreAddressRepository : EfCoreRepository<CoreDbContext, Address, Guid>, IAddressRepository
    {
        public EfCoreAddressRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<AddressWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Address.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<AddressWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null,
            Guid? countryId = null,
            Guid? stateOrProvinceId = null,
            Guid? cityId = null,
            Guid? districtId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, contactName, phone, addressLine1, addressLine2, zipOrPostalCode, countryId, stateOrProvinceId, cityId, districtId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AddressConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<AddressWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from address in (await GetDbSetAsync())
                   join country in (await GetDbContextAsync()).Countries on address.CountryId equals country.Id into countries
                   from country in countries.DefaultIfEmpty()
                   join stateOrProvince in (await GetDbContextAsync()).StateOrProvinces on address.StateOrProvinceId equals stateOrProvince.Id into stateOrProvinces
                   from stateOrProvince in stateOrProvinces.DefaultIfEmpty()
                   join city in (await GetDbContextAsync()).Cities on address.CityId equals city.Id into cities
                   from city in cities.DefaultIfEmpty()
                   join district in (await GetDbContextAsync()).Districts on address.DistrictId equals district.Id into districts
                   from district in districts.DefaultIfEmpty()

                   select new AddressWithNavigationProperties
                   {
                       Address = address,
                       Country = country,
                       StateOrProvince = stateOrProvince,
                       City = city,
                       District = district
                   };
        }

        protected virtual IQueryable<AddressWithNavigationProperties> ApplyFilter(
            IQueryable<AddressWithNavigationProperties> query,
            string filterText,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null,
            Guid? countryId = null,
            Guid? stateOrProvinceId = null,
            Guid? cityId = null,
            Guid? districtId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Address.ContactName.Contains(filterText) || e.Address.Phone.Contains(filterText) || e.Address.AddressLine1.Contains(filterText) || e.Address.AddressLine2.Contains(filterText) || e.Address.ZipOrPostalCode.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactName), e => e.Address.ContactName.Contains(contactName))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Address.Phone.Contains(phone))
                    .WhereIf(!string.IsNullOrWhiteSpace(addressLine1), e => e.Address.AddressLine1.Contains(addressLine1))
                    .WhereIf(!string.IsNullOrWhiteSpace(addressLine2), e => e.Address.AddressLine2.Contains(addressLine2))
                    .WhereIf(!string.IsNullOrWhiteSpace(zipOrPostalCode), e => e.Address.ZipOrPostalCode.Contains(zipOrPostalCode))
                    .WhereIf(countryId != null && countryId != Guid.Empty, e => e.Country != null && e.Country.Id == countryId)
                    .WhereIf(stateOrProvinceId != null && stateOrProvinceId != Guid.Empty, e => e.StateOrProvince != null && e.StateOrProvince.Id == stateOrProvinceId)
                    .WhereIf(cityId != null && cityId != Guid.Empty, e => e.City != null && e.City.Id == cityId)
                    .WhereIf(districtId != null && districtId != Guid.Empty, e => e.District != null && e.District.Id == districtId);
        }

        public async Task<List<Address>> GetListAsync(
            string filterText = null,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, contactName, phone, addressLine1, addressLine2, zipOrPostalCode);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AddressConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null,
            Guid? countryId = null,
            Guid? stateOrProvinceId = null,
            Guid? cityId = null,
            Guid? districtId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, contactName, phone, addressLine1, addressLine2, zipOrPostalCode, countryId, stateOrProvinceId, cityId, districtId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Address> ApplyFilter(
            IQueryable<Address> query,
            string filterText,
            string contactName = null,
            string phone = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string zipOrPostalCode = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ContactName.Contains(filterText) || e.Phone.Contains(filterText) || e.AddressLine1.Contains(filterText) || e.AddressLine2.Contains(filterText) || e.ZipOrPostalCode.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactName), e => e.ContactName.Contains(contactName))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Phone.Contains(phone))
                    .WhereIf(!string.IsNullOrWhiteSpace(addressLine1), e => e.AddressLine1.Contains(addressLine1))
                    .WhereIf(!string.IsNullOrWhiteSpace(addressLine2), e => e.AddressLine2.Contains(addressLine2))
                    .WhereIf(!string.IsNullOrWhiteSpace(zipOrPostalCode), e => e.ZipOrPostalCode.Contains(zipOrPostalCode));
        }
    }
}