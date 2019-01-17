using System.Collections.Generic;
using Et.Yhy.Roles.Dto;

namespace Et.Yhy.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
