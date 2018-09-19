using Majid.Application.Features;
using Majid.Domain.Repositories;
using Majid.MultiTenancy;
using Future.Authorization.Users;
using Future.Editions;

namespace Future.MultiTenancy
{
    public class TenantManager : MajidTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IMajidZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
