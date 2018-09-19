using System.ComponentModel.DataAnnotations;
using Majid.Authorization.Users;
using Majid.AutoMapper;
using Majid.MultiTenancy;

namespace Future.MultiTenancy.Dto
{
    [AutoMapTo(typeof(Tenant))]
    public class CreateTenantDto
    {
        [Required]
        [StringLength(MajidTenantBase.MaxTenancyNameLength)]
        [RegularExpression(MajidTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(MajidTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(MajidTenantBase.MaxConnectionStringLength)]
        public string ConnectionString { get; set; }

        public bool IsActive {get; set;}
    }
}
