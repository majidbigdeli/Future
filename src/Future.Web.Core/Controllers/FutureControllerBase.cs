using Majid.AspNetCore.Mvc.Controllers;
using Majid.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Future.Controllers
{
    public abstract class FutureControllerBase: MajidController
    {
        protected FutureControllerBase()
        {
            LocalizationSourceName = FutureConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
