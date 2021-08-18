using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    [Serializable]
    public class StateOrProvinceCodeAlreadyExistException : BusinessException
    {
        public StateOrProvinceCodeAlreadyExistException([NotNull] string stateOrProvinceCode)
        {
            Code = CoreErrorCodes.StateOrProvinceCodeAlreadyExist;
            WithData("StateOrProvinceCode", stateOrProvinceCode);
        }
        
        public StateOrProvinceCodeAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
    }
}