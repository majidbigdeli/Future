using System.Threading.Tasks;
using Majid.Authorization;
using Majid.Runtime.Session;
using Future.Configuration.Dto;

namespace Future.Configuration
{
    [MajidAuthorize]
    public class ConfigurationAppService : FutureAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(MajidSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
