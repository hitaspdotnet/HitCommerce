using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.ActivityLog.EntityFrameworkCore
{
    public class ActivityLogModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ActivityLogModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}