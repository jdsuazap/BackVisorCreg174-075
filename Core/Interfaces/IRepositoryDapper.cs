namespace Core.Interfaces
{
    using Dapper.Oracle;
    using System.Linq.Expressions;

    public interface IRepositoryDapper<T>
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
        Task ExecuteNonQuery(string sqlCommand);
        Task<T?> EjecutarConsultaAsync<T>(string query, OracleDynamicParameters parameters) where T : class;

        Task<IEnumerable<TOut>> EjecutarConsultaListAsync<TOut>(string query) where TOut : class;
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
