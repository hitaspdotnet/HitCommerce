using Hitasp.HitCommerce.Core.StateOrProvinces;
using Hitasp.HitCommerce.Core.Countries;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Core.EntityFrameworkCore
{
    [DependsOn(
        typeof(CoreDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CoreEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CoreDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Country, Countries.EfCoreCountryRepository>();

                options.AddRepository<StateOrProvince, StateOrProvinces.EfCoreStateOrProvinceRepository>();

            });
        }
    }
}