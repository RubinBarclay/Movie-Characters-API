namespace Movie_Characters_API.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(int id) : base($"Character with id {id} was not found")
        { 
        }
    }
}
