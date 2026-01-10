using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : DomainEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = false, params Expression<Func<T, object>>[] includeObjectProperties);
        Task<T> GetById(object id);
        Task Add(T entity);
        Task AddRange(List<T> entities);
        Task Update(T entity);
        Task Delete(string id);
        Task ExecuteNonQuery(string sqlCommand);
    }
}
