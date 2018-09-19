using Majid.Application.Features;
using Majid.Domain.Repositories;
using Majid.Domain.Uow;
using Majid.MultiTenancy;
using Majid.Runtime.Caching;
using Future.Authorization.Users;
using Future.MultiTenancy;

namespace Future.Features
{
    public class FeatureValueStore : MajidFeatureValueStore<Tenant, User>
    {
        public FeatureValueStore(
            ICacheManager cacheManager, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            IRepository<Tenant> tenantRepository, 
            IRepository<EditionFeatureSetting, long> editionFeatureRepository, 
            IFeatureManager featureManager, 
            IUnitOfWorkManager unitOfWorkManager) 
            : base(
                  cacheManager, 
                  tenantFeatureRepository, 
                  tenantRepository, 
                  editionFeatureRepository, 
                  featureManager, 
                  unitOfWorkManager)
        {
        }
    }
}
