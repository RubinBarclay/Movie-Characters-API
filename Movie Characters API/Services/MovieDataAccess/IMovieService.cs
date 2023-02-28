using Movie_Characters_API.Models;

namespace Movie_Characters_API.Service.MovieDataAccess
{
    public interface IMovieService : ICrudRepository<Movie,int>
    {
    }
}
