using Movie_Characters_API.Models;
using Movie_Characters_API.Services.FranchiseDataAccess;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Exceptions;

namespace Movie_Characters_API.Services.FranchiseDataAccess
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieDbContext _context;

        public FranchiseService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Franchise> Create(Franchise obj)
        {
            await _context.Franchises.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public Task Deletes(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Franchise>> GetAll()
        {
            return await _context.Franchises.Include(x => x.Movies).ToListAsync();
        }

        public async Task<Franchise> GetById(int id)
        {
            var franchise = await _context.Franchises.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            if (franchise is null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise;

        }

        public Task<Franchise> Update(Franchise obj)
        {
            throw new NotImplementedException();
        }
    }
}
