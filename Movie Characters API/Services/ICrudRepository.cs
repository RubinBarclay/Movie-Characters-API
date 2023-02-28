namespace Movie_Characters_API.Services
{
    public interface ICrudRepository<T, ID>
    {

        Task<IEnumerable<T>> GetAll();

        T GetById(ID id);

        Task<T> Create(T obj);

        Task<T> Update(T obj);

        Task Deletes(ID id);
    }
}
