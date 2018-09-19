using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Majid.Events.Bus;
using Majid.Modules;
using Majid.Reflection.Extensions;
using Future.Configuration;
using Future.EntityFrameworkCore;
using Future.Migrator.DependencyInjection;

namespace Future.Migrator
{
    [DependsOn(typeof(FutureEntityFrameworkModule))]
    public class FutureMigratorModule : MajidModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FutureMigratorModule(FutureEntityFrameworkModule majidProjectNameEntityFrameworkModule)
        {
            majidProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(FutureMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                FutureConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FutureMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
