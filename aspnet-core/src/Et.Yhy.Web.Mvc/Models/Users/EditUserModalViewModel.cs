using System.Collections.Generic;
using System.Linq;
using Et.Yhy.Complay.Dtos;
using Et.Yhy.Roles.Dto;
using Et.Yhy.Users.Dto;

namespace Et.Yhy.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
        public IReadOnlyList<ComplaysListDto> Com { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
        public bool UserIsCom(ComplaysListDto com) {
            return User.ComplaysId >0 && com.Users.Any(r => r.Id == User.ComplaysId);
        }
    }
}
