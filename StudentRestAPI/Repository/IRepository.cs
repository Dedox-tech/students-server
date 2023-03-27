namespace StudentRestAPI.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadOne(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
