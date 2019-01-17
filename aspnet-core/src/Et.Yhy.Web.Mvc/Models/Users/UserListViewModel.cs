using System.Collections.Generic;
using Et.Yhy.Complay.Dtos;
using Et.Yhy.Roles.Dto;
using Et.Yhy.Users.Dto;

namespace Et.Yhy.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
        public IReadOnlyList<ComplaysListDto> Com { get; set; }
    }
}
