using Majid.Modules;
using Majid.Reflection.Extensions;
using Majid.Timing;
using Majid.Zero;
using Majid.Zero.Configuration;
using Future.Authorization.Roles;
using Future.Authorization.Users;
using Future.Configuration;
using Future.Localization;
using Future.MultiTenancy;
using Future.Timing;

namespace Future
{
    [DependsOn(typeof(MajidZeroCoreModule))]
    public class FutureCoreModule : MajidModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            FutureLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = FutureConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FutureCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
