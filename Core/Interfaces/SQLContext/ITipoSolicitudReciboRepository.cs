using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoSolicitudReciboRepository
    {
        Task<TipoSolicitudRecibo> CreateEntity(TipoSolicitudRecibo entity);
        Task<bool> DeleteEntity(TipoSolicitudRecibo entity);
        Task<List<TipoSolicitudRecibo>> GetEntities();
        Task<TipoSolicitudRecibo> GetEntity(int idEntity);
        Task<TipoSolicitudRecibo> UpdateEntity(TipoSolicitudRecibo entity);
    }
}
