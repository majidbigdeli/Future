using Majid.Application.Services.Dto;
using Majid.AutoMapper;
using Majid.Authorization;

namespace Future.Roles.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
