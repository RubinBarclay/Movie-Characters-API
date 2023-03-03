using Movie_Characters_API.Models;
using Movie_Characters_API.Services.CharacterDataAccess;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Exceptions;

namespace Movie_Characters_API.Services.CharacterDataAccess
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieDbContext _context;

        public CharacterService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Character> Create(Character obj)
        {
            await _context.Characters.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }


            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> ReadAll()
        {
            return await _context.Characters.Include(x => x.MoviesList).ToListAsync();
             
        }

        public async Task<Character> ReadById(int id)
        {
            var character = await _context.Characters.Include(x => x.MoviesList).FirstOrDefaultAsync(x => x.Id == id);

            if (character is null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        public async Task<Character> Update(Character obj)
        {
            var foundCharacter = await _context.Characters.AnyAsync(x => x.Id == obj.Id);
            if (!foundCharacter)
            {
                throw new CharacterNotFoundException(obj.Id);
            }
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
