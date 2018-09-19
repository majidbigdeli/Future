using Microsoft.EntityFrameworkCore;
using Majid.Zero.EntityFrameworkCore;
using Future.Authorization.Roles;
using Future.Authorization.Users;
using Future.MultiTenancy;
using Majid.Localization;

namespace Future.EntityFrameworkCore
{
    public class FutureDbContext : MajidZeroDbContext<Tenant, Role, User, FutureDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public FutureDbContext(DbContextOptions<FutureDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }
    }
}
