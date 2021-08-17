using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductRecentlyViewed.EntityFrameworkCore
{
    [DependsOn(
        typeof(ProductRecentlyViewedDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class ProductRecentlyViewedEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ProductRecentlyViewedDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}