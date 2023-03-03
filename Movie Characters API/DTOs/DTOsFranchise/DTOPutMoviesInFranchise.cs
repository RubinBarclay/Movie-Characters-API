using Movie_Characters_API.DTOs.DTOsMovie;
using Movie_Characters_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.DTOs.DTOsFranchise
{
    public class DTOPutMoviesInFranchise
    {
        public List<int>? MovieIds { get; set; }
    }
}
