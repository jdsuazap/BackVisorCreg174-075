using Core.Entities.SQLContext;
using System.Linq.Expressions;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionReviewRepository
    {
        Task<SolServicioConexionReview> GetEntity(int idEntity);
        Task<SolServicioConexionReview> GetEntityBySolServcioConexionId(int idEntity);
        Task<SolServicioConexionReview> CreateEntity(SolServicioConexionReview entity);
        Task<SolServicioConexionReview> UpdateEntity(SolServicioConexionReview entity);
        Task<List<SolServicioConexionReview>> GetAllAsync(Expression<Func<SolServicioConexionReview, bool>> filter = null,
            Func<IQueryable<SolServicioConexionReview>, IOrderedQueryable<SolServicioConexionReview>>? orderBy = null
            , bool isTracking = false,
            params Expression<Func<SolServicioConexionReview, object>>[] includeObjectProperties);
    }
}
