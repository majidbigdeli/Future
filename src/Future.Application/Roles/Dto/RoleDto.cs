using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Majid.Application.Services.Dto;
using Majid.Authorization.Roles;
using Majid.AutoMapper;
using Future.Authorization.Roles;

namespace Future.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class RoleDto : EntityDto<int>
    {
        [Required]
        [StringLength(MajidRoleBase.MaxNameLength)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(MajidRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }
        
        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public List<string> Permissions { get; set; }
    }
}