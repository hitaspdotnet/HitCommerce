using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Search.EntityFrameworkCore
{
    public class SearchModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public SearchModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}