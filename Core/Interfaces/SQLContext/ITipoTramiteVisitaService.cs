using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoTramiteVisitaService
    {
        Task<TipoTramiteVisita> CreateEntity(TipoTramiteVisita entity);
        Task<bool> DeleteEntity(TipoTramiteVisita entity);
        Task<List<TipoTramiteVisita>> GetEntities();
        Task<TipoTramiteVisita> GetEntity(int idEntity);
        Task<TipoTramiteVisita> UpdateEntity(TipoTramiteVisita entity);
    }
}
