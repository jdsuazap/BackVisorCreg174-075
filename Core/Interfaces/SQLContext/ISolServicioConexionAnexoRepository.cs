using Core.Entities.SQLContext;
using System.Linq.Expressions;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionAnexoRepository
    {
        Task<SolServicioConexionAnexo> CreateEntity(SolServicioConexionAnexo entity);
        Task<List<SolServicioConexionAnexo>> CreateEntity_Range(List<SolServicioConexionAnexo> entity);
        Task<bool> DeleteEntity(SolServicioConexionAnexo entity);
        Task<List<SolServicioConexionAnexo>> GetEntities();
        Task<SolServicioConexionAnexo> GetEntity(int idEntity);
        Task<SolServicioConexionAnexo> UpdateEntity(SolServicioConexionAnexo entity);
        Task<List<SolServicioConexionAnexo>> GetAll(
                                        Expression<Func<SolServicioConexionAnexo, bool>> filter = null,
                                        Func<IQueryable<SolServicioConexionAnexo>, IOrderedQueryable<SolServicioConexionAnexo>>? orderBy = null,
                                        Func<IQueryable<SolServicioConexionAnexo>, IOrderedQueryable<SolServicioConexionAnexo>>? orderByDescending = null,
                                        bool isTracking = false,
                                        params Expression<Func<SolServicioConexionAnexo, object>>[] includeObjectProperties);
    }
}
