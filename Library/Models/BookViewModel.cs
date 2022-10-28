using Library.Data;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.TitleMinLength)]
        [MaxLength(ValidationConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.AuthorMinLength)]
        [MaxLength(ValidationConstants.AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [Range(typeof(decimal),"0.00","10.00", ConvertValueInInvariantCulture=false)]
        public decimal Rating { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string Category { get; set; } = null!;
    }
}
