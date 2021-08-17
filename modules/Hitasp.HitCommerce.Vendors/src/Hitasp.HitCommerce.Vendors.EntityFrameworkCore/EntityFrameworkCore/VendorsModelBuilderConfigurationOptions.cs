using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Vendors.EntityFrameworkCore
{
    public class VendorsModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public VendorsModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}