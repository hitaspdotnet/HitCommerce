using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Shipments.EntityFrameworkCore
{
    public class ShipmentsModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ShipmentsModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}