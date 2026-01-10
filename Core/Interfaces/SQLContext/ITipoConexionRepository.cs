using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoConexionRepository
    {
        Task<TipoConexion> CreateEntity(TipoConexion entity);
        Task<bool> DeleteEntity(TipoConexion entity);
        Task<List<TipoConexion>> GetEntities();
        Task<TipoConexion> GetEntity(int idEntity);
        Task<TipoConexion> UpdateEntity(TipoConexion entity);
    }
}
