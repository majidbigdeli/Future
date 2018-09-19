using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Majid.Application.Services;
using Majid.IdentityFramework;
using Majid.Runtime.Session;
using Future.Authorization.Users;
using Future.MultiTenancy;

namespace Future
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class FutureAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected FutureAppServiceBase()
        {
            LocalizationSourceName = FutureConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(MajidSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(MajidSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
