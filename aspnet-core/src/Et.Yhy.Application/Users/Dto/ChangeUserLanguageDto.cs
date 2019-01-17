using System.ComponentModel.DataAnnotations;

namespace Et.Yhy.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}