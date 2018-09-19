using System;
using Castle.MicroKernel.Registration;
using NSubstitute;
using Majid.AutoMapper;
using Majid.Dependency;
using Majid.Modules;
using Majid.Configuration.Startup;
using Majid.Net.Mail;
using Majid.TestBase;
using Majid.Zero.Configuration;
using Majid.Zero.EntityFrameworkCore;
using Future.EntityFrameworkCore;
using Future.Tests.DependencyInjection;

namespace Future.Tests
{
    [DependsOn(
        typeof(FutureApplicationModule),
        typeof(FutureEntityFrameworkModule),
        typeof(MajidTestBaseModule)
        )]
    public class FutureTestModule : MajidModule
    {
        public FutureTestModule(FutureEntityFrameworkModule majidProjectNameEntityFrameworkModule)
        {
            majidProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
            majidProjectNameEntityFrameworkModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            // Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.MajidAutoMapper().UseStaticMapper = false;

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<MajidZeroDbMigrator<FutureDbContext>>();

            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}
