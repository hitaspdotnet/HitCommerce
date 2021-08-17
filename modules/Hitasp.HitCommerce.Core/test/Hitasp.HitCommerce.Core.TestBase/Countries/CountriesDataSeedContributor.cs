using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Hitasp.HitCommerce.Core.Countries;

namespace Hitasp.HitCommerce.Core.Countries
{
    public class CountriesDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesDataSeedContributor(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _countryRepository.InsertAsync(new Country
            (
                id: Guid.Parse("0b621552-262f-45a4-959c-318775610919"),
                name: "6fc3df27994940f8bf69b2f352dbf9ecb9cdc94f5beb44ca9baae85712ef948733c3d031fb544f47bb3f27a423a13ee2146f738b059f4ef2bb2a768ab058b27ad5fd447c6a5c47dbb269fa35d5e8ebfeb395ea0746624e4c876118461c63238a4e58dd56b9e44410ae98f7519e0ff912fd013ae6825b40c9a882b707ead79553c635bc1a0c2d4ca9b85ad135bf224383752633193d744d948a35b1f5454f30b9d91bf976289e44c1a69b379dd278bcbe917a46c689f34d21b56c1d619745edd7eb9d58c780ff4d53b560f29afaea8c1aa537a5f7cdd94e78ba54b03299e3e55864",
                code3: "e77",
                isBillingEnabled: true,
                isShippingEnabled: true
            ));

            await _countryRepository.InsertAsync(new Country
            (
                id: Guid.Parse("ba73600e-4701-410e-a9b9-0afd61802c3a"),
                name: "4547c317e5904102ac37a9df71948523d2bcf020560941258fc8c88270e51a107063740733a7405aae00cf900aaf97c144db7da9e27347a286cd022da0c61ddb2fdba16f468a4589b2a6e4d36768606f0d7ff0fdd6c5442b9240ea00e63fcd8e76d2dea76eae4622aa58a80a750bd776cf30211cc3c746d5b34a1e98115307d8ad80bdea2ae247f98ae46f508249094f56362dc0a8f34c2fbb10b5e9e7a24cde760689516bf44959b341ccba6de4610e88aa109971b947d18021977b93a7f239adacf8cec9844229a3e4673729220839abf733b4734d40a994c92ee46900ef9f5e",
                code3: "ca6",
                isBillingEnabled: true,
                isShippingEnabled: true
            ));
        }
    }
}