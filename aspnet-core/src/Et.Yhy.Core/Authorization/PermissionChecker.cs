using Abp.Authorization;
using Et.Yhy.Authorization.Roles;
using Et.Yhy.Authorization.Users;

namespace Et.Yhy.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
