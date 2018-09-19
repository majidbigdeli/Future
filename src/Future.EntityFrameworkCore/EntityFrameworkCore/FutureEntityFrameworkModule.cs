using Majid.EntityFrameworkCore.Configuration;
using Majid.Modules;
using Majid.Reflection.Extensions;
using Majid.Zero.EntityFrameworkCore;
using Future.EntityFrameworkCore.Seed;

namespace Future.EntityFrameworkCore
{
    [DependsOn(
        typeof(FutureCoreModule), 
        typeof(MajidZeroCoreEntityFrameworkCoreModule))]
    public class FutureEntityFrameworkModule : MajidModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.MajidEfCore().AddDbContext<FutureDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        FutureDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        FutureDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FutureEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
