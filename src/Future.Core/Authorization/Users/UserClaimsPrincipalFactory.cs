using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Majid.Authorization;
using Future.Authorization.Roles;

namespace Future.Authorization.Users
{
    public class UserClaimsPrincipalFactory : MajidUserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor)
        {
        }
    }
}
