using Majid.Domain.Uow;
using Majid.EntityFrameworkCore;
using Majid.MultiTenancy;
using Majid.Zero.EntityFrameworkCore;

namespace Future.EntityFrameworkCore
{
    public class MajidZeroDbMigrator : MajidZeroDbMigrator<FutureDbContext>
    {
        public MajidZeroDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IDbContextResolver dbContextResolver)
            : base(
                unitOfWorkManager,
                connectionStringResolver,
                dbContextResolver)
        {
        }
    }
}
