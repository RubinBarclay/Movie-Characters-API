using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.FranchiseDataAccess
{
    public interface IFranchiseService : ICrudRepository<Franchise,int>
    {
        /// <summary>
        /// Get all movies in franchise
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="FranchiseNotFoundException">Thrown if franchise is not found</exception>
        /// <returns>IEnumerable of movies</returns>
        Task<IEnumerable<Movie>> ReadAllMoviesInFranchise(int id);

        /// <summary>
        /// Get all characters in franchise
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="FranchiseNotFoundException">Thrown if franchise is not found</exception>
        /// <returns>IEnumerable of movies</returns>
        Task<IEnumerable<Character>> ReadAllCharactersInFranchise(int id);
    }
}
