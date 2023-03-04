using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.MovieDataAccess
{
    public interface IMovieService : ICrudRepository<Movie,int>
    {
        /// <summary>
        /// Get all characters in movie
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="MovieNotFoundException">Thrown if franchise is not found</exception>
        /// <returns>IEnumerable of movies</returns>
        Task<IEnumerable<Character>> ReadAllCharacterInMovie(int id);
    }
}
