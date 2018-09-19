using Majid.Authorization;
using Future.Authorization.Roles;
using Future.Authorization.Users;

namespace Future.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
