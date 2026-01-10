using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoTensionRepository : IRepository<TipoTension>
    {
        Task<TipoTension> CreateEntity(TipoTension entity);
        Task<bool> DeleteEntity(TipoTension entity);
        Task<List<TipoTension>> GetEntities();
        Task<TipoTension> GetEntity(int idEntity);
        Task<TipoTension> UpdateEntity(TipoTension entity);
    }
}
