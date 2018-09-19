using Majid.Authorization.Roles;
using Majid.Domain.Repositories;
using Majid.Domain.Uow;
using Future.Authorization.Users;

namespace Future.Authorization.Roles
{
    public class RoleStore : MajidRoleStore<Role, User>
    {
        public RoleStore(
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<Role> roleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                unitOfWorkManager,
                roleRepository,
                rolePermissionSettingRepository)
        {
        }
    }
}
