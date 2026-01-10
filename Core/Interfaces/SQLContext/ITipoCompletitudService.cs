using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoCompletitudService
    {
        Task<TipoCompletitud> CreateEntity(TipoCompletitud entity);
        Task<bool> DeleteEntity(TipoCompletitud entity);
        Task<List<TipoCompletitud>> GetEntities();
        Task<TipoCompletitud> GetEntity(int idEntity);
        Task<TipoCompletitud> UpdateEntity(TipoCompletitud entity);
    }
}
