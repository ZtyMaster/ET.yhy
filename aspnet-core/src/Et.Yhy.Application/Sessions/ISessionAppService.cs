using System.Threading.Tasks;
using Abp.Application.Services;
using Et.Yhy.Sessions.Dto;

namespace Et.Yhy.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
