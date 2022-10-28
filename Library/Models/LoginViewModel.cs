using Library.Data;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(ValidationConstants.UserNameMinLength)]
        [MaxLength(ValidationConstants.UserNameMaxLength)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
