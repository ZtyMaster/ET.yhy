using System.Collections.Generic;
using Et.Yhy.Roles.Dto;

namespace Et.Yhy.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}