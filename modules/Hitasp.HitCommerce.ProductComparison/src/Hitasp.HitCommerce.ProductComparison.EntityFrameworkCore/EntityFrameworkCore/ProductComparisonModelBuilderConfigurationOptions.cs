using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.ProductComparison.EntityFrameworkCore
{
    public class ProductComparisonModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ProductComparisonModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}