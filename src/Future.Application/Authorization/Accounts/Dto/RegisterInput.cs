using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Majid.Auditing;
using Majid.Authorization.Users;
using Majid.Extensions;
using Future.Validation;

namespace Future.Authorization.Accounts.Dto
{
    public class RegisterInput : IValidatableObject
    {
        [Required]
        [StringLength(MajidUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(MajidUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        [DisableAuditing]
        public string CaptchaResponse { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!UserName.IsNullOrEmpty())
            {
                if (!UserName.Equals(EmailAddress) && ValidationHelper.IsEmail(UserName))
                {
                    yield return new ValidationResult("Username cannot be an email address unless it's the same as your email address!");
                }
            }
        }
    }
}
