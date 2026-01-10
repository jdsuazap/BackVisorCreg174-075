using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoAerogeneradorRepository
    {
        Task<TipoAerogenerador> CreateEntity(TipoAerogenerador entity);
        Task<bool> DeleteEntity(TipoAerogenerador entity);
        Task<List<TipoAerogenerador>> GetEntities();
        Task<TipoAerogenerador> GetEntity(int idEntity);
        Task<TipoAerogenerador> UpdateEntity(TipoAerogenerador entity);
    }
}
