using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.MovieDataAccess
{
    public interface IMovieService : ICrudRepository<Movie,int>
    {
   
    }
}
