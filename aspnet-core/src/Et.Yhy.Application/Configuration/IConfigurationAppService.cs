using System.Threading.Tasks;
using Et.Yhy.Configuration.Dto;

namespace Et.Yhy.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
