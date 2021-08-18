using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    [Serializable]
    public class StateOrProvinceNameAlreadyExistException : BusinessException
    {
        public StateOrProvinceNameAlreadyExistException([NotNull] string stateOrProvinceName)
        {
            Code = CoreErrorCodes.StateOrProvinceNameAlreadyExist;
            WithData("StateOrProvinceName", stateOrProvinceName);
        }
        
        public StateOrProvinceNameAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
    }
}