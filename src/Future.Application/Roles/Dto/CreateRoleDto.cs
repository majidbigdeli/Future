using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Majid.Authorization.Roles;
using Majid.AutoMapper;
using Future.Authorization.Roles;

namespace Future.Roles.Dto
{
    [AutoMapTo(typeof(Role))]
    public class CreateRoleDto
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
