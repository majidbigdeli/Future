using System.ComponentModel.DataAnnotations;

namespace Future.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}