using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public MovieDto()
        {
            DateAdded = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


        [Required(ErrorMessage = "Please select a Genre for the movie")]
        public byte GenreId { get; set; }

        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public DateTime DateAdded { get; set; }

    }
}