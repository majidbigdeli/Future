using Majid.Application.Services.Dto;
using Majid.AutoMapper;
using Future.MultiTenancy;

namespace Future.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
