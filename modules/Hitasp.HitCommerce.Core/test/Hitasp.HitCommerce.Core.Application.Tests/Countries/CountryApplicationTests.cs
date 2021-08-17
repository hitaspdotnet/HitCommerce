using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Hitasp.HitCommerce.Core.Countries
{
    public class CountriesAppServiceTests : CoreApplicationTestBase
    {
        private readonly ICountriesAppService _countriesAppService;
        private readonly IRepository<Country, Guid> _countryRepository;

        public CountriesAppServiceTests()
        {
            _countriesAppService = GetRequiredService<ICountriesAppService>();
            _countryRepository = GetRequiredService<IRepository<Country, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _countriesAppService.GetListAsync(new GetCountriesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("0b621552-262f-45a4-959c-318775610919")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("ba73600e-4701-410e-a9b9-0afd61802c3a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _countriesAppService.GetAsync(Guid.Parse("0b621552-262f-45a4-959c-318775610919"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("0b621552-262f-45a4-959c-318775610919"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CountryCreateDto
            {
                Name = "b16218660fd248c5b8a4f3bb0bd6b28b99ab4b5bccea4e6faad7c41d1ec53def51a8351349904e099fbc70677f4d88780eb127defe8e4663a5bab054aad3d8ff5cbc39cf47c34527a9052a046d38a82b1eb52a6255c7476684d6f5fcfd06f81be0458612fdb04cc29d2afd510042e6bb5819013a909145e0966882f9d721c3cd7ebf124c6d08427f9a6474b9b346f69842d4ed9a64c045f29c32bca8d4e62384fc6ee9bd0b914b7199eea3505294bb05af37074b304241669ae14f22cb31d6bc9bedee2f2c4147ff9bb9d4eff6eec9f524cbe65862674f8d82595d0e750b7102bd",
                Code3 = "206",
                IsBillingEnabled = true,
                IsShippingEnabled = true
            };

            // Act
            var serviceResult = await _countriesAppService.CreateAsync(input);

            // Assert
            var result = await _countryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("b16218660fd248c5b8a4f3bb0bd6b28b99ab4b5bccea4e6faad7c41d1ec53def51a8351349904e099fbc70677f4d88780eb127defe8e4663a5bab054aad3d8ff5cbc39cf47c34527a9052a046d38a82b1eb52a6255c7476684d6f5fcfd06f81be0458612fdb04cc29d2afd510042e6bb5819013a909145e0966882f9d721c3cd7ebf124c6d08427f9a6474b9b346f69842d4ed9a64c045f29c32bca8d4e62384fc6ee9bd0b914b7199eea3505294bb05af37074b304241669ae14f22cb31d6bc9bedee2f2c4147ff9bb9d4eff6eec9f524cbe65862674f8d82595d0e750b7102bd");
            result.Code3.ShouldBe("206");
            result.IsBillingEnabled.ShouldBe(true);
            result.IsShippingEnabled.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CountryUpdateDto()
            {
                Name = "db69e78793844841ac37dc73c44a099ac2fa0a5fcd2e4856ba7f799a6b70207f25e623f5471041098eec36ac9b5116c6a2ad90b39149498f9e8b0ca321be05ac5ff6a8932f09440e9ee24fd87332af9abfc83758bc9c4205b01462e2b945c5f1577c333242ff4f84be4d76b152efc9b9219eeb86cbef477294fee99bea04cffad2ff22986dc04edb85a358de0f530b96b0e5928309f545bab0fc7fff447c0ad515c78f7d030e4573af6b349bff6173b25d3836040bd246f1b48e67aad7986c27165650d2d8104496ae09d9fff26d4f5e5119abd095e64e97b0c89544fc51901bf2",
                Code3 = "f16",
                IsBillingEnabled = true,
                IsShippingEnabled = true
            };

            // Act
            var serviceResult = await _countriesAppService.UpdateAsync(Guid.Parse("0b621552-262f-45a4-959c-318775610919"), input);

            // Assert
            var result = await _countryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("db69e78793844841ac37dc73c44a099ac2fa0a5fcd2e4856ba7f799a6b70207f25e623f5471041098eec36ac9b5116c6a2ad90b39149498f9e8b0ca321be05ac5ff6a8932f09440e9ee24fd87332af9abfc83758bc9c4205b01462e2b945c5f1577c333242ff4f84be4d76b152efc9b9219eeb86cbef477294fee99bea04cffad2ff22986dc04edb85a358de0f530b96b0e5928309f545bab0fc7fff447c0ad515c78f7d030e4573af6b349bff6173b25d3836040bd246f1b48e67aad7986c27165650d2d8104496ae09d9fff26d4f5e5119abd095e64e97b0c89544fc51901bf2");
            result.Code3.ShouldBe("f16");
            result.IsBillingEnabled.ShouldBe(true);
            result.IsShippingEnabled.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _countriesAppService.DeleteAsync(Guid.Parse("0b621552-262f-45a4-959c-318775610919"));

            // Assert
            var result = await _countryRepository.FindAsync(c => c.Id == Guid.Parse("0b621552-262f-45a4-959c-318775610919"));

            result.ShouldBeNull();
        }
    }
}