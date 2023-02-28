using Movie_Characters_API.Models;
using Movie_Characters_API.Services.FranchiseDataAccess;
using Microsoft.EntityFrameworkCore;

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

        public Task<IEnumerable<Franchise>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Franchise GetById(int id)
        {
            var franchise = await _context.Franchises.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            if (franchise is null)
            {
                throw new BrandNotFoundException(id);
            }

            return franchise;

        }

        public Task<Franchise> Update(Franchise obj)
        {
            throw new NotImplementedException();
        }
    }
}
