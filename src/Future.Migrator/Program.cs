using System;
using Castle.Facilities.Logging;
using Majid;
using Majid.Castle.Logging.Log4Net;
using Majid.Collections.Extensions;
using Majid.Dependency;

namespace Future.Migrator
{
    public class Program
    {
        private static bool _quietMode;

        public static void Main(string[] args)
        {
            ParseArgs(args);

            using (var bootstrapper = MajidBootstrapper.Create<FutureMigratorModule>())
            {
                bootstrapper.IocManager.IocContainer
                    .AddFacility<LoggingFacility>(
                        f => f.UseMajidLog4Net().WithConfig("log4net.config")
                    );

                bootstrapper.Initialize();

                using (var migrateExecuter = bootstrapper.IocManager.ResolveAsDisposable<MultiTenantMigrateExecuter>())
                {
                    var migrationSucceeded = migrateExecuter.Object.Run(_quietMode);
                    
                    if (_quietMode)
                    {
                        // exit clean (with exit code 0) if migration is a success, otherwise exit with code 1
                        var exitCode = Convert.ToInt32(!migrationSucceeded);
                        Environment.Exit(exitCode);
                    }
                    else
                    {
                        Console.WriteLine("Press ENTER to exit...");
                        Console.ReadLine();
                    }
                }
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.IsNullOrEmpty())
            {
                return;
            }

            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-q":
                        _quietMode = true;
                        break;
                }
            }
        }
    }
}
