using Majid.AutoMapper;
using Majid.Modules;
using Majid.Reflection.Extensions;
using Future.Authorization;

namespace Future
{
    [DependsOn(
        typeof(FutureCoreModule), 
        typeof(MajidAutoMapperModule))]
    public class FutureApplicationModule : MajidModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FutureAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FutureApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.MajidAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
