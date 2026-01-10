using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoSolicitudServicioRepository
    {
        Task<TipoSolicitudServicio> CreateEntity(TipoSolicitudServicio entity);
        Task<bool> DeleteEntity(TipoSolicitudServicio entity);
        Task<List<TipoSolicitudServicio>> GetEntities();
        Task<TipoSolicitudServicio> GetEntity(int idEntity);
        Task<TipoSolicitudServicio> UpdateEntity(TipoSolicitudServicio entity);
    }
}
