using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.Cities
{
    public interface ICityManager : IDomainService
    {
        Task<City> CreateAsync(Guid stateOrProvinceId, [NotNull] string name, [CanBeNull] string type = "");

        Task RenameAsync([NotNull] City city, [NotNull] string newName);
    }
}