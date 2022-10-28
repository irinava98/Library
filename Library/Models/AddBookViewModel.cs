using Library.Data;
using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {

        [Required]
        [MinLength(ValidationConstants.TitleMinLength)]
        [MaxLength(ValidationConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.AuthorMinLength)]
        [MaxLength(ValidationConstants.AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.DescriptionMinLength)]
        [MaxLength(ValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.00", "10.00", ConvertValueInInvariantCulture = false)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new HashSet<Category>();   
    }
}
