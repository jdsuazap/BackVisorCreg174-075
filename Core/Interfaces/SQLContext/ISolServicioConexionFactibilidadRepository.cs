using Core.Entities.SQLContext;
using System.Linq.Expressions;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionFactibilidadRepository
    {
        Task<SolServicioConexionFactibilidad> CreateEntity(SolServicioConexionFactibilidad entity);
        Task<bool> DeleteEntity(SolServicioConexionFactibilidad entity);
        Task<List<SolServicioConexionFactibilidad>> GetEntities();
        Task<SolServicioConexionFactibilidad> GetEntity(long idEntity);
        Task<SolServicioConexionFactibilidad> UpdateEntity(SolServicioConexionFactibilidad entity);
        Task<List<SolServicioConexionFactibilidad>> GetAllAsync(Expression<Func<SolServicioConexionFactibilidad, bool>> filter = null, Func<IQueryable<SolServicioConexionFactibilidad>, IOrderedQueryable<SolServicioConexionFactibilidad>>? orderBy = null, bool isTracking = false, params Expression<Func<SolServicioConexionFactibilidad, object>>[] includeObjectProperties);
    }
}
