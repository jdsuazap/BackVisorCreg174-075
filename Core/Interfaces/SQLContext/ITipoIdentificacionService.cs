using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoIdentificacionService
    {
        Task<TipoIdentificacion> CreateEntity(TipoIdentificacion entity);
        Task<bool> DeleteEntity(TipoIdentificacion entity);
        Task<List<TipoIdentificacion>> GetEntities();
        Task<TipoIdentificacion> GetEntity(int idEntity);
        Task<TipoIdentificacion> UpdateEntity(TipoIdentificacion entity);
    }
}
