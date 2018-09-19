using System.Threading.Tasks;
using Future.Configuration.Dto;

namespace Future.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
