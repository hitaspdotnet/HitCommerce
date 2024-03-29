﻿using Hitasp.HitCommerce.Catalog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Catalog.Permissions
{
    public class CatalogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CatalogPermissions.GroupName, L("Permission:Catalog"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CatalogResource>(name);
        }
    }
}