using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Tax.EntityFrameworkCore
{
    public class TaxModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public TaxModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}