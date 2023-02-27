using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [MaxLength(100)]
        public string Director { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string TrailerUrl { get; set; }
    }
}
