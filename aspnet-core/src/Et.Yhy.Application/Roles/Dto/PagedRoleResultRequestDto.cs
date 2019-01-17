using Abp.Application.Services.Dto;

namespace Et.Yhy.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

