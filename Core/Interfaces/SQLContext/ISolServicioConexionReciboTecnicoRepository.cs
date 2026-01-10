using Core.Entities.SQLContext;
using System.Linq.Expressions;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionReciboTecnicoRepository
    {
        Task<List<SolServicioConexionReciboTecnico>> GetEntities();
        Task<SolServicioConexionReciboTecnico> GetEntity(long idEntity);
        Task<SolServicioConexionReciboTecnico> CreateEntity(SolServicioConexionReciboTecnico entity);
        Task<SolServicioConexionReciboTecnico> UpdateEntity(SolServicioConexionReciboTecnico entity);
        Task<bool> DeleteEntity(SolServicioConexionReciboTecnico entity);
        Task<List<SolServicioConexionReciboTecnico>> GetAllAsync(Expression<Func<SolServicioConexionReciboTecnico, bool>> filter = null,
                                                                Func<IQueryable<SolServicioConexionReciboTecnico>, IOrderedQueryable<SolServicioConexionReciboTecnico>>? orderBy = null,
                                                                bool isTracking = false, params Expression<Func<SolServicioConexionReciboTecnico, object>>[] includeObjectProperties);
    }
}
