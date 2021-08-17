using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.ProductComparison.EntityFrameworkCore
{
    [DependsOn(
        typeof(ProductComparisonDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class ProductComparisonEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ProductComparisonDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}