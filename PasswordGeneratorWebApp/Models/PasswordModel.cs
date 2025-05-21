using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorWebApp.Models
{
    public class PasswordModel
    {
        [Required]
        [Range(1, 128, ErrorMessage = "Password length must be between 1 and 128.")]
        public int Length { get; set; }

        public bool IncludeUppercase { get; set; }

        public bool IncludeNumbers { get; set; }

        public bool IncludeSpecialCharacters { get; set; }
    }
}