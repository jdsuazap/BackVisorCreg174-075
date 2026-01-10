using Core.Entities.SQLContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.SQLContext
{
    public interface IPasosSolServicioConexionService
    {
        Task<PasosSolServicioConexion> CreateEntity(PasosSolServicioConexion entity);
        Task<bool> DeleteEntity(PasosSolServicioConexion entity);
        Task<List<PasosSolServicioConexion>> GetEntities();
        Task<PasosSolServicioConexion> GetEntity(int idEntity);
        Task<PasosSolServicioConexion> UpdateEntity(PasosSolServicioConexion entity);
    }
}
