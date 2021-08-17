using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.Countries
{
    public interface ICountryManager : IDomainService
    {
        Task<Country> CreateAsync([NotNull] string name, [CanBeNull] string code3 = "", bool isBillingEnabled = false,
            bool isShippingEnabled = false);

        Task RenameAsync([NotNull] Country country, [NotNull] string newName);

        Task ChangeCodeAsync([NotNull] Country country, string newCode);
    }
}