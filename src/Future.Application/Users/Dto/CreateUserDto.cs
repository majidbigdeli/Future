using System.ComponentModel.DataAnnotations;
using Majid.Auditing;
using Majid.Authorization.Users;
using Majid.AutoMapper;
using Majid.Runtime.Validation;
using Future.Authorization.Users;

namespace Future.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class CreateUserDto : IShouldNormalize
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

        public string[] RoleNames { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public void Normalize()
        {
            if (RoleNames == null)
            {
                RoleNames = new string[0];
            }
        }
    }
}
