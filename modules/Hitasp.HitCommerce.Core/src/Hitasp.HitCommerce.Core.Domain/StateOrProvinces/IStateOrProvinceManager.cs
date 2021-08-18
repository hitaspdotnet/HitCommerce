using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public interface IStateOrProvinceManager : IDomainService
    {
        Task<StateOrProvince> CreateAsync(Guid countryId, [NotNull] string name, [CanBeNull] string code3 = "", string type = "");

        Task RenameAsync([NotNull] StateOrProvince stateOrProvince, [NotNull] string newName);

        Task ChangeCodeAsync([NotNull] StateOrProvince stateOrProvince, string newCode);
       
    }
}