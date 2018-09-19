using Majid.MultiTenancy;
using Future.Authorization.Users;

namespace Future.MultiTenancy
{
    public class Tenant : MajidTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
