namespace Movie_Characters_API.Service
{
    public interface ICrudRepository<T, ID>
    {

        IEnumerable<T> GetAll();

        T GetById(ID id);

        void Add(T obj);

        void Update(T obj);

        void Deletes(T obj);
    }
}
