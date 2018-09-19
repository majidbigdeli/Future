using System.ComponentModel.DataAnnotations;
using Majid.MultiTenancy;

namespace Future.Authorization.Accounts.Dto
{
    public class IsTenantAvailableInput
    {
        [Required]
        [StringLength(MajidTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }
    }
}
