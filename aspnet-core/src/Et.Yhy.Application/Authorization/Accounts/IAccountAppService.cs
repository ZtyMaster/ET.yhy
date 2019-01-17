using System.Threading.Tasks;
using Abp.Application.Services;
using Et.Yhy.Authorization.Accounts.Dto;

namespace Et.Yhy.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
