using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Majid.Modules;
using Majid.Reflection.Extensions;
using Future.Configuration;

namespace Future.Web.Host.Startup
{
    [DependsOn(
       typeof(FutureWebCoreModule))]
    public class FutureWebHostModule: MajidModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FutureWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FutureWebHostModule).GetAssembly());
        }
    }
}
