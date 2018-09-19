using System.Threading.Tasks;
using Majid.Application.Services;
using Majid.Application.Services.Dto;
using Future.Roles.Dto;
using Future.Users.Dto;

namespace Future.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
