﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Cms
{
    [DependsOn(
        typeof(CmsApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CmsHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Cms";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CmsApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
