using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Majid;
using Majid.Authorization.Users;
using Majid.Events.Bus;
using Majid.Events.Bus.Entities;
using Majid.MultiTenancy;
using Majid.Runtime.Session;
using Majid.TestBase;
using Future.Authorization.Users;
using Future.EntityFrameworkCore;
using Future.EntityFrameworkCore.Seed.Host;
using Future.EntityFrameworkCore.Seed.Tenants;
using Future.MultiTenancy;

namespace Future.Tests
{
    public abstract class FutureTestBase : MajidIntegratedTestBase<FutureTestModule>
    {
        protected FutureTestBase()
        {
            void NormalizeDbContext(FutureDbContext context)
            {
                context.EntityChangeEventHelper = NullEntityChangeEventHelper.Instance;
                context.EventBus = NullEventBus.Instance;
                context.SuppressAutoSetTenantId = true;
            }

            // Seed initial data for host
            MajidSession.TenantId = null;
            UsingDbContext(context =>
            {
                NormalizeDbContext(context);
                new InitialHostDbBuilder(context).Create();
                new DefaultTenantBuilder(context).Create();
            });

            // Seed initial data for default tenant
            MajidSession.TenantId = 1;
            UsingDbContext(context =>
            {
                NormalizeDbContext(context);
                new TenantRoleAndUserBuilder(context, 1).Create();
            });

            LoginAsDefaultTenantAdmin();
        }

        #region UsingDbContext

        protected IDisposable UsingTenantId(int? tenantId)
        {
            var previousTenantId = MajidSession.TenantId;
            MajidSession.TenantId = tenantId;
            return new DisposeAction(() => MajidSession.TenantId = previousTenantId);
        }

        protected void UsingDbContext(Action<FutureDbContext> action)
        {
            UsingDbContext(MajidSession.TenantId, action);
        }

        protected Task UsingDbContextAsync(Func<FutureDbContext, Task> action)
        {
            return UsingDbContextAsync(MajidSession.TenantId, action);
        }

        protected T UsingDbContext<T>(Func<FutureDbContext, T> func)
        {
            return UsingDbContext(MajidSession.TenantId, func);
        }

        protected Task<T> UsingDbContextAsync<T>(Func<FutureDbContext, Task<T>> func)
        {
            return UsingDbContextAsync(MajidSession.TenantId, func);
        }

        protected void UsingDbContext(int? tenantId, Action<FutureDbContext> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<FutureDbContext>())
                {
                    action(context);
                    context.SaveChanges();
                }
            }
        }

        protected async Task UsingDbContextAsync(int? tenantId, Func<FutureDbContext, Task> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<FutureDbContext>())
                {
                    await action(context);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected T UsingDbContext<T>(int? tenantId, Func<FutureDbContext, T> func)
        {
            T result;

            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<FutureDbContext>())
                {
                    result = func(context);
                    context.SaveChanges();
                }
            }

            return result;
        }

        protected async Task<T> UsingDbContextAsync<T>(int? tenantId, Func<FutureDbContext, Task<T>> func)
        {
            T result;

            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<FutureDbContext>())
                {
                    result = await func(context);
                    await context.SaveChangesAsync();
                }
            }

            return result;
        }

        #endregion

        #region Login

        protected void LoginAsHostAdmin()
        {
            LoginAsHost(MajidUserBase.AdminUserName);
        }

        protected void LoginAsDefaultTenantAdmin()
        {
            LoginAsTenant(MajidTenantBase.DefaultTenantName, MajidUserBase.AdminUserName);
        }

        protected void LoginAsHost(string userName)
        {
            MajidSession.TenantId = null;

            var user =
                UsingDbContext(
                    context =>
                        context.Users.FirstOrDefault(u => u.TenantId == MajidSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for host.");
            }

            MajidSession.UserId = user.Id;
        }

        protected void LoginAsTenant(string tenancyName, string userName)
        {
            var tenant = UsingDbContext(context => context.Tenants.FirstOrDefault(t => t.TenancyName == tenancyName));
            if (tenant == null)
            {
                throw new Exception("There is no tenant: " + tenancyName);
            }

            MajidSession.TenantId = tenant.Id;

            var user =
                UsingDbContext(
                    context =>
                        context.Users.FirstOrDefault(u => u.TenantId == MajidSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for tenant: " + tenancyName);
            }

            MajidSession.UserId = user.Id;
        }

        #endregion

        /// <summary>
        /// Gets current user if <see cref="IMajidSession.UserId"/> is not null.
        /// Throws exception if it's null.
        /// </summary>
        protected async Task<User> GetCurrentUserAsync()
        {
            var userId = MajidSession.GetUserId();
            return await UsingDbContext(context => context.Users.SingleAsync(u => u.Id == userId));
        }

        /// <summary>
        /// Gets current tenant if <see cref="IMajidSession.TenantId"/> is not null.
        /// Throws exception if there is no current tenant.
        /// </summary>
        protected async Task<Tenant> GetCurrentTenantAsync()
        {
            var tenantId = MajidSession.GetTenantId();
            return await UsingDbContext(context => context.Tenants.SingleAsync(t => t.Id == tenantId));
        }
    }
}
