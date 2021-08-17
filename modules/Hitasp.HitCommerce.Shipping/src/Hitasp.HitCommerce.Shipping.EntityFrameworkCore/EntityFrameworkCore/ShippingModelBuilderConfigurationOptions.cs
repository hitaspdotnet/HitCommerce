using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Shipping.EntityFrameworkCore
{
    public class ShippingModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ShippingModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}