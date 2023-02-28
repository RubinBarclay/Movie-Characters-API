using Movie_Characters_API.Models;
using Movie_Characters_API.Services.MovieDataAccess;

namespace Movie_Characters_API.Services.MovieDataAccess
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public Task<Movie> Create(Movie obj)
        {
            throw new NotImplementedException();
        }

        public Task Deletes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Update(Movie obj)
        {
            throw new NotImplementedException();
        }
    }
}
