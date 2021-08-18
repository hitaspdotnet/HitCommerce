using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Countries
{
    [Serializable]
    public class CountryCodeAlreadyExistException : BusinessException
    {
        public CountryCodeAlreadyExistException([NotNull] string countryCode)
        {
            Code = CoreErrorCodes.CountryCodeAlreadyExist;
            WithData("CountryCode", countryCode);
        }
        
        public CountryCodeAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
    }
}