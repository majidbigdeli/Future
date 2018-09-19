using System.ComponentModel.DataAnnotations;
using Majid.Application.Services.Dto;
using Majid.Authorization.Roles;
using Future.Authorization.Roles;

namespace Future.Roles.Dto
{
    public class RoleEditDto: EntityDto<int>
    {
        [Required]
        [StringLength(MajidRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MajidRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        public bool IsStatic { get; set; }
    }
}