using Microsoft.EntityFrameworkCore;
using StudentRestAPI.Data;
using StudentRestAPI.Models;
using System.Linq.Expressions;

namespace StudentRestAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly DatabaseContext context;

        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> ReadOne(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ReadByCriteria(Expression<Func<T, bool>> criteria)
        {
            return await context.Set<T>().Where(criteria).ToListAsync();
        }

        public async Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
