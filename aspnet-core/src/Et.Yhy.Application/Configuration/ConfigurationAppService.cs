using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Et.Yhy.Configuration.Dto;

namespace Et.Yhy.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : YhyAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
