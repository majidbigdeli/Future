using Majid.Application.Services;
using Majid.Application.Services.Dto;
using Future.MultiTenancy.Dto;

namespace Future.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
