namespace Movie_Characters_API.Exceptions
{
    public class FranchiseNotFoundException : Exception
    {
        FranchiseNotFoundException(int id) : base($"Franchise with id {id} was not found") 
        {
        }
    }
}
