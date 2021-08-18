using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Countries
{
    [Serializable]
    public class CountryNameAlreadyExistException : BusinessException
    {
        public CountryNameAlreadyExistException([NotNull] string countryName)
        {
            Code = CoreErrorCodes.CountryNameAlreadyExist;
            WithData("CountryName", countryName);
        }
        
        public CountryNameAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
    }
}