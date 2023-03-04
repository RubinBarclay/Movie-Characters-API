using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.MovieDataAccess
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> Create(Movie obj)
        {
            await _context.Movies.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(int id)
        {
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                throw new MovieNotFoundException(id);
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> ReadAll()
        {
            return await _context.Movies.Include(x => x.Characters).ToListAsync();
        }

        public async Task<IEnumerable<Character>> ReadAllCharactersInMovie(int id)
        {
            var movie = await _context.Movies.Include(x => x.Characters).FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
            {
                throw new MovieNotFoundException(id);
            }
            return movie.Characters;
        }

        public async Task<Movie> ReadById(int id)
        {
            var movie = await _context.Movies.Include(x => x.Characters).FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
            {
                throw new MovieNotFoundException(id);
            }

            return movie;
        }

        public async Task<Movie> Update(Movie obj)
        {
            var foundMovie = await _context.Movies.AnyAsync(x => x.Id == obj.Id);
            if (!foundMovie)
            {
                throw new MovieNotFoundException(obj.Id);
            }
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        
    }
}
