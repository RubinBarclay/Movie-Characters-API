using Movie_Characters_API.Models;
using Movie_Characters_API.Services.FranchiseDataAccess;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Exceptions;
using System.Reflection.Emit;

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

        public async Task Deletes(int id)
        {
            var franchis = await _context.Franchises.FindAsync(id);
            if (franchis == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            

            _context.Franchises.Remove(franchis);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Franchise>> GetAll()
        {
            return await _context.Franchises.Include(x => x.MovieList).ToListAsync();
        }

        public async Task<Franchise> GetById(int id)
        {
            var franchise = await _context.Franchises.Include(x => x.MovieList).FirstOrDefaultAsync(x => x.Id == id);

            if (franchise is null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise;

        }

        public async Task<Franchise> Update(Franchise obj)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == obj.Id);
            if (!foundFranchise)
            {
                throw new FranchiseNotFoundException(obj.Id);
            }
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
