using System;
using System.ComponentModel.DataAnnotations;
using Majid.Application.Services.Dto;
using Majid.Authorization.Users;
using Majid.AutoMapper;
using Future.Authorization.Users;

namespace Future.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        [Required]
        [StringLength(MajidUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(MajidUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] RoleNames { get; set; }
    }
}
