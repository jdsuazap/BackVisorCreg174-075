using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoGeneracionRepository
    {
        Task<TipoGeneracion> CreateEntity(TipoGeneracion entity);
        Task<bool> DeleteEntity(TipoGeneracion entity);
        Task<List<TipoGeneracion>> GetEntities();
        Task<TipoGeneracion> GetEntity(int idEntity);
        Task<TipoGeneracion> UpdateEntity(TipoGeneracion entity);
    }
}
