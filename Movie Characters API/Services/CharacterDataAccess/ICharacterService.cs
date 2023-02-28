using Movie_Characters_API.Models;

namespace Movie_Characters_API.Services.CharacterDataAccess
{
    public interface ICharacterService : ICrudRepository<Character,int>
    {
    }
}
