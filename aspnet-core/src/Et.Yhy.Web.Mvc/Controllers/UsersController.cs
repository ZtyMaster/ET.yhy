using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Et.Yhy.Authorization;
using Et.Yhy.Controllers;
using Et.Yhy.Users;
using Et.Yhy.Web.Models.Users;
using Et.Yhy.Users.Dto;
using Et.Yhy.Complay;

namespace Et.Yhy.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : YhyControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IComplaysAppService  _complays;

        public UsersController(IUserAppService userAppService, IComplaysAppService ComplaysAppService)
        {
            _userAppService = userAppService;
            _complays = ComplaysAppService;
        }

        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto {MaxResultCount = int.MaxValue})).Items; // Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var com = (await _complays.GetAll()).Items;
            var model = new UserListViewModel
            {
                Users = users,
                Roles = roles,
                Com=com
            };
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            
            var roles = (await _userAppService.GetRoles()).Items;
           // var com = (await _complays.GetAll()).Items;
          
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
    }
}
