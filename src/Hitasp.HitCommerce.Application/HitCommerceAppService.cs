using System;
using System.Collections.Generic;
using System.Text;
using Hitasp.HitCommerce.Localization;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce
{
    /* Inherit your application services from this class.
     */
    public abstract class HitCommerceAppService : ApplicationService
    {
        protected HitCommerceAppService()
        {
            LocalizationResource = typeof(HitCommerceResource);
        }
    }
}