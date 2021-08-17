using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    public class CatalogModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public CatalogModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}