using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.Districts
{
    public interface IDistrictManager : IDomainService
    {
        Task<District> CreateAsync(Guid cityId, [NotNull] string name, [CanBeNull] string type = "");

        Task RenameAsync([NotNull] District district, [NotNull] string newName);
    }
}