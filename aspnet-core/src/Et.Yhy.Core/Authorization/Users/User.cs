using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using Et.Yhy.Complay;

namespace Et.Yhy.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public string WXid { get; set; }
        public int? ComplaysId {  get; set; }
        public Complays Complays { get; set; }

        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
