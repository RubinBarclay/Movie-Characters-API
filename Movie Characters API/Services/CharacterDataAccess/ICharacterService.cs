using Movie_Characters_API.Models;

namespace Movie_Characters_API.Service.CharacterDataAccess
{
    public interface ICharacterService : ICrudRepository<Character,int>
    {
    }
}
