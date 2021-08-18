using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Cities
{
    [Serializable]
    public class CityNameAlreadyExistException : BusinessException
    {
        public CityNameAlreadyExistException([NotNull] string cityName)
        {
            Code = CoreErrorCodes.CityNameAlreadyExist;
            WithData("CityName", cityName);
        }
        
        public CityNameAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
    }
}