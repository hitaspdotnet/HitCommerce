﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Hitasp.HitCommerce.Catalog.Samples
{
    public class SampleAppService : CatalogAppService, ISampleAppService
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