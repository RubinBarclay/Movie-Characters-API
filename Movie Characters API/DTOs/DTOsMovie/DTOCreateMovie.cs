using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.DTOs.DTOsMovie
{
    public class DTOCreateMovie
    {
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
        [Url]
        public string PictureUrl { get; set; }
        [Required]
        [Url]
        public string TrailerUrl { get; set; }
        public int? FranchiseId { get; set; }
    }
}
