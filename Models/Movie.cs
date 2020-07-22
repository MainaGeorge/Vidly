using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please select a Genre for the movie")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Available copies in Stock")]
        public byte NumberInStock { get; set; }


    }
}