﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Hitasp.HitCommerce.Shipping.Samples
{
    public class SampleAppService : ShippingAppService, ISampleAppService
    {
        public Task<SampleDto> GetAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }

        [Authorize]
        public Task<SampleDto> GetAuthorizedAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }
    }
}