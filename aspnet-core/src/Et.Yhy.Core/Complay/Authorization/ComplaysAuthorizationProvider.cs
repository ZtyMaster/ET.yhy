

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using Et.Yhy.Authorization;

namespace Et.Yhy.Complay.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ComplaysPermissions" /> for all permission names. Complays
    ///</summary>
    public class ComplaysAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ComplaysAuthorizationProvider()
		{

		}

        public ComplaysAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ComplaysAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Complays 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(ComplaysPermissions.Node , L("Complays"));
			entityPermission.CreateChildPermission(ComplaysPermissions.Query, L("QueryComplays"));
			entityPermission.CreateChildPermission(ComplaysPermissions.Create, L("CreateComplays"));
			entityPermission.CreateChildPermission(ComplaysPermissions.Edit, L("EditComplays"));
			entityPermission.CreateChildPermission(ComplaysPermissions.Delete, L("DeleteComplays"));
			entityPermission.CreateChildPermission(ComplaysPermissions.BatchDelete, L("BatchDeleteComplays"));
			entityPermission.CreateChildPermission(ComplaysPermissions.ExportExcel, L("ExportExcelComplays"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, YhyConsts.LocalizationSourceName);
		}
    }
}