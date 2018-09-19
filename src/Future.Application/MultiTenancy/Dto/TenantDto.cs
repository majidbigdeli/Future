using System.ComponentModel.DataAnnotations;
using Majid.Application.Services.Dto;
using Majid.AutoMapper;
using Majid.MultiTenancy;

namespace Future.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantDto : EntityDto
    {
        [Required]
        [StringLength(MajidTenantBase.MaxTenancyNameLength)]
        [RegularExpression(MajidTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(MajidTenantBase.MaxNameLength)]
        public string Name { get; set; }        
        
        public bool IsActive {get; set;}
    }
}
