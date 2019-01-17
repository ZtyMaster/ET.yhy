using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Et.Yhy.Roles.Dto;
using Et.Yhy.Users.Dto;

namespace Et.Yhy.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
