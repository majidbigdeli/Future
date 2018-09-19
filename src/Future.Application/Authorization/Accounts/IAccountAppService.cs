using System.Threading.Tasks;
using Majid.Application.Services;
using Future.Authorization.Accounts.Dto;

namespace Future.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
