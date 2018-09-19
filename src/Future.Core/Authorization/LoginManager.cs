using Microsoft.AspNetCore.Identity;
using Majid.Authorization;
using Majid.Authorization.Users;
using Majid.Configuration;
using Majid.Configuration.Startup;
using Majid.Dependency;
using Majid.Domain.Repositories;
using Majid.Domain.Uow;
using Majid.Zero.Configuration;
using Future.Authorization.Roles;
using Future.Authorization.Users;
using Future.MultiTenancy;

namespace Future.Authorization
{
    public class LogInManager : MajidLogInManager<Tenant, Role, User>
    {
        public LogInManager(
            UserManager userManager, 
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager, 
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository, 
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            IPasswordHasher<User> passwordHasher, 
            RoleManager roleManager,
            UserClaimsPrincipalFactory claimsPrincipalFactory) 
            : base(
                  userManager, 
                  multiTenancyConfig,
                  tenantRepository, 
                  unitOfWorkManager, 
                  settingManager, 
                  userLoginAttemptRepository, 
                  userManagementConfig, 
                  iocResolver, 
                  passwordHasher, 
                  roleManager, 
                  claimsPrincipalFactory)
        {
        }
    }
}
