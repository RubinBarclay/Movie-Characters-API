using Movie_Characters_API.Models;

namespace Movie_Characters_API.Service.FranchiseDataAccess
{
    public interface IFranchiseService : ICrudRepository<Franchise,int>
    {
    }
}
