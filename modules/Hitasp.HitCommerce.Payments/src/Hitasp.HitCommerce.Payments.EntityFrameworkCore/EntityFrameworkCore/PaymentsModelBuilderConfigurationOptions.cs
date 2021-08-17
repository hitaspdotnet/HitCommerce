using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Payments.EntityFrameworkCore
{
    public class PaymentsModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public PaymentsModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}