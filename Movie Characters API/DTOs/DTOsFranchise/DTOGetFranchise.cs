﻿using Movie_Characters_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.DTOs.DTOsFranchise
{
    public class DTOGetFranchise
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public List<string> Movies { get; set; }

    }
}
