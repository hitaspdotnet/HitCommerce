using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.ShoppingCart.EntityFrameworkCore
{
    public class ShoppingCartModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ShoppingCartModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}