using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}