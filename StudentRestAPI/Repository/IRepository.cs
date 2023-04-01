using System.Linq.Expressions;

namespace StudentRestAPI.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> ReadAll();
        Task<IEnumerable<T>> ReadByCriteria(Expression<Func<T, bool>> criteria);
        Task<T> ReadOne(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
