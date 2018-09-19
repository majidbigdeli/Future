using System.ComponentModel.DataAnnotations;
using Majid.Authorization.Users;

namespace Future.Models.TokenAuth
{
    public class AuthenticateModel
    {
        [Required]
        [StringLength(MajidUserBase.MaxEmailAddressLength)]
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        [StringLength(MajidUserBase.MaxPlainPasswordLength)]
        public string Password { get; set; }
        
        public bool RememberClient { get; set; }
    }
}
