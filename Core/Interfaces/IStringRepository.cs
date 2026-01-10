using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStringRepository<T> where T : StringBaseEntity
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = false, params Expression<Func<T, object>>[] includeObjectProperties);
        Task<T> GetById(string id);
        Task Add(T entity);
        Task AddRange(List<T> entities);
        Task Update(T entity);
        Task Delete(string id);
        Task ExecuteNonQuery(string sqlCommand);
    }
}
