using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(25)]
        public string? Alias { get; set; }

        [Required]
        [MaxLength(6)]
        public string Gender{ get; set; }
        [Required]
        public string PictureUrl { get; set;}
    }
}
