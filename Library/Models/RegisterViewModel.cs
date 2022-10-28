using Library.Data;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(ValidationConstants.UserNameMinLength)]
        [MaxLength(ValidationConstants.UserNameMaxLength)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.EmailMinLength)]
        [MaxLength(ValidationConstants.EmailMaxLength)] 
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
