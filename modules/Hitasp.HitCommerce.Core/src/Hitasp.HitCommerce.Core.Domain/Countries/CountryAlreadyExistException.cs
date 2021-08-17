using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Countries
{
    [Serializable]
    public class CountryAlreadyExistException : BusinessException
    {
        public CountryAlreadyExistException([NotNull] string countryName)
        {
            Code = CoreErrorCodes.CountryAlreadyExist;
            WithData("CountryName", countryName);
        }
        
        public CountryAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
    }
}