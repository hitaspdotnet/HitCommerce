using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Pricing.EntityFrameworkCore
{
    public class PricingModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public PricingModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}