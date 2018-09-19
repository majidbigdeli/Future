using System.Threading.Tasks;
using Majid.Application.Services;
using Future.Sessions.Dto;

namespace Future.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
