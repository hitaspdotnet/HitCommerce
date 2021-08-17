using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Storage.EntityFrameworkCore
{
    public class StorageModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public StorageModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}