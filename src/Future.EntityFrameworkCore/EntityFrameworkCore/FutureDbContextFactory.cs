using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Future.Configuration;
using Future.Web;

namespace Future.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FutureDbContextFactory : IDesignTimeDbContextFactory<FutureDbContext>
    {
        public FutureDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FutureDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FutureDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FutureConsts.ConnectionStringName));

            return new FutureDbContext(builder.Options);
        }
    }
}
