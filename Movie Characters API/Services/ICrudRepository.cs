namespace Movie_Characters_API.Services
{
    public interface ICrudRepository<T, ID>
    {
        Task<T> Create(T obj);

        Task<IEnumerable<T>> ReadAll();

        Task<T> ReadById(ID id);

        Task<T> Update(T obj);

        Task Delete(ID id);
    }
}
