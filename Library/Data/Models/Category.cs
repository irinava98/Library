﻿using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Books=new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
