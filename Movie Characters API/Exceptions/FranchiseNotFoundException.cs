namespace Movie_Characters_API.Exceptions
{
    public class FranchiseNotFoundException : Exception
    {
        public FranchiseNotFoundException(int id) : base($"Franchise with id {id} was not found") 
        {
        }
    }
}
