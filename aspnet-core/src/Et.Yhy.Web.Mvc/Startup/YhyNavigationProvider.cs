using Abp.Application.Navigation;
using Abp.Localization;
using Et.Yhy.Authorization;

namespace Et.Yhy.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class YhyNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                  new MenuItemDefinition(
                      "adminsting",
                      L("adminsting"),
                      icon:"menu").AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                      new MenuItemDefinition(
                        PageNames.Complays,
                        L("Complays"),
                        url: "Complays",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Complays
                     ) 
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "info"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, YhyConsts.LocalizationSourceName);
        }
    }
}
