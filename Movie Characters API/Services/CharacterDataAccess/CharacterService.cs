using Movie_Characters_API.Models;
using Movie_Characters_API.Services.CharacterDataAccess;
using Microsoft.EntityFrameworkCore;

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

        public Task Deletes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Character GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Character> Update(Character obj)
        {
            throw new NotImplementedException();
        }
    }
}
