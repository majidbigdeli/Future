using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Future.EntityFrameworkCore
{
    public static class FutureDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FutureDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FutureDbContext> builder, DbConnection connection)
        {
             builder.UseNpgsql(connection);
        }
    }
}
