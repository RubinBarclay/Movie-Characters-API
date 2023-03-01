using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.DTOs.DTOFranchiseModels
{
    public class DTOCreateFranchise
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
