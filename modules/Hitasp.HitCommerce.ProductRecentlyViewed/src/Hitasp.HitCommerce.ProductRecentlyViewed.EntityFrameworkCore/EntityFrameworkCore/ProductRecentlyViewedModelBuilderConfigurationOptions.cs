using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.EntityFrameworkCore
{
    public class ProductRecentlyViewedModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ProductRecentlyViewedModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}