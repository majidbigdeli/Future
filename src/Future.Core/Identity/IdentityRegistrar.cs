using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Future.Authorization;
using Future.Authorization.Roles;
using Future.Authorization.Users;
using Future.Editions;
using Future.MultiTenancy;

namespace Future.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddMajidIdentity<Tenant, User, Role>()
                .AddMajidTenantManager<TenantManager>()
                .AddMajidUserManager<UserManager>()
                .AddMajidRoleManager<RoleManager>()
                .AddMajidEditionManager<EditionManager>()
                .AddMajidUserStore<UserStore>()
                .AddMajidRoleStore<RoleStore>()
                .AddMajidLogInManager<LogInManager>()
                .AddMajidSignInManager<SignInManager>()
                .AddMajidSecurityStampValidator<SecurityStampValidator>()
                .AddMajidUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
