using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        #region Métodos DbSQLContext
        Task<List<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByDescending = null,
            bool isTracking = false,
            params Expression<Func<T, object>>[] includeObjectProperties);
        Task<T> GetById(int id);
        Task Add(T entity);
        Task AddRange(List<T> entities);
        Task Update(T entity);
        Task Delete(int id);
        Task DeleteEntityRange(List<T> entities);
        //Task ExecuteNonQuery(string sqlCommand);
        #endregion

        #region Métodos Dapper
        Task<IEnumerable<T>> Dapper_GetEntities(
            string query,
            Type[] relatedEntities,
            Func<object[], T> mapFunc,
            Func<IEnumerable<T>, IEnumerable<T>> groupAndProjectFunc,
            object param
        );
        #endregion
    }
}
