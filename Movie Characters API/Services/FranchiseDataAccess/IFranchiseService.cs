using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.FranchiseDataAccess
{
    public interface IFranchiseService : ICrudRepository<Franchise,int>
    {
    }
}
