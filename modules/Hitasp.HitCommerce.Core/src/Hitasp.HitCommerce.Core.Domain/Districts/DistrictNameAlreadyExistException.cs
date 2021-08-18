using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Core.Districts
{
    [Serializable]
    public class DistrictNameAlreadyExistException : BusinessException
    {
        public DistrictNameAlreadyExistException([NotNull] string districtName)
        {
            Code = CoreErrorCodes.DistrictNameAlreadyExist;
            WithData("DistrictName", districtName);
        }
        
        public DistrictNameAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
    }
}