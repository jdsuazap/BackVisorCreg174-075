using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoServicioRepository : IRepository<TipoServicio>
    {
        Task<TipoServicio> CreateEntity(TipoServicio entity);
        Task<bool> DeleteEntity(TipoServicio entity);
        Task<List<TipoServicio>> GetEntities();
        Task<TipoServicio> GetEntity(int idEntity);
        Task<TipoServicio> UpdateEntity(TipoServicio entity);
    }
}
