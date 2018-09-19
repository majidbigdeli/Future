using System.Threading.Tasks;
using Majid.Application.Services;
using Majid.Application.Services.Dto;
using Future.Roles.Dto;

namespace Future.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);
    }
}