using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public class StateOrProvinceManager : DomainService, IStateOrProvinceManager
    {
        protected IStateOrProvinceRepository StateOrProvinceRepository { get; }

        public StateOrProvinceManager(IStateOrProvinceRepository stateOrProvinceRepository)
        {
            StateOrProvinceRepository = stateOrProvinceRepository;
        }

        public virtual async Task<StateOrProvince> CreateAsync(Guid countryId, string name, string code3, string type)
        {
            await CheckStateOrProvinceName(countryId, name);
            await CheckStateOrProvinceCode(countryId, code3);

            return new StateOrProvince(GuidGenerator.Create(), countryId, name, code3, type);
        }

        public virtual async Task RenameAsync(StateOrProvince stateOrProvince, string newName)
        {
            if (string.Equals(stateOrProvince.Name.Trim(), newName.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            await CheckStateOrProvinceName(stateOrProvince.CountryId, newName);
            stateOrProvince.SetName(newName);
        }

        public virtual async Task ChangeCodeAsync(StateOrProvince stateOrProvince, string newCode)
        {
            if (stateOrProvince.Code3 != null && string.Equals(stateOrProvince.Code3.Trim(), newCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            await CheckStateOrProvinceCode(stateOrProvince.CountryId, newCode);
            stateOrProvince.SetCode3(newCode);
        }

        protected virtual async Task CheckStateOrProvinceName(Guid countryId, string name)
        {
            var stateOrProvince = await StateOrProvinceRepository.FindByNameAsync(countryId, name);
            if (stateOrProvince != null)
            {
                throw new StateOrProvinceNameAlreadyExistException(name);
            }
        }

        protected virtual async Task CheckStateOrProvinceCode(Guid countryId, string code)
        {
            var stateOrProvince = await StateOrProvinceRepository.FindByCodeAsync(countryId, code);
            if (stateOrProvince != null)
            {
                throw new StateOrProvinceCodeAlreadyExistException(code);
            }
        }
    }
}