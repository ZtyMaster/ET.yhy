

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using Et.Yhy.Authorization;

namespace Et.Yhy.BuMens.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BumenPermissions" /> for all permission names. Bumen
    ///</summary>
    public class BumenAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BumenAuthorizationProvider()
		{

		}

        public BumenAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BumenAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Bumen 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(BumenPermissions.Node , L("Bumen"));
			entityPermission.CreateChildPermission(BumenPermissions.Query, L("QueryBumen"));
			entityPermission.CreateChildPermission(BumenPermissions.Create, L("CreateBumen"));
			entityPermission.CreateChildPermission(BumenPermissions.Edit, L("EditBumen"));
			entityPermission.CreateChildPermission(BumenPermissions.Delete, L("DeleteBumen"));
			entityPermission.CreateChildPermission(BumenPermissions.BatchDelete, L("BatchDeleteBumen"));
			entityPermission.CreateChildPermission(BumenPermissions.ExportExcel, L("ExportExcelBumen"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, YhyConsts.LocalizationSourceName);
		}
    }
}