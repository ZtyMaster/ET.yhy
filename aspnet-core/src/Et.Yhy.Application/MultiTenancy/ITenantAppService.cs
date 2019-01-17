using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Et.Yhy.MultiTenancy.Dto;

namespace Et.Yhy.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

