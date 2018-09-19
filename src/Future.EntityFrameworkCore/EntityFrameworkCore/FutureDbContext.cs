using Microsoft.EntityFrameworkCore;
using Majid.Zero.EntityFrameworkCore;
using Future.Authorization.Roles;
using Future.Authorization.Users;
using Future.MultiTenancy;

namespace Future.EntityFrameworkCore
{
    public class FutureDbContext : MajidZeroDbContext<Tenant, Role, User, FutureDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public FutureDbContext(DbContextOptions<FutureDbContext> options)
            : base(options)
        {
        }
    }
}
