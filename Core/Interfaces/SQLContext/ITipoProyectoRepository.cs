using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoProyectoRepository
    {
        Task<TipoProyecto> CreateEntity(TipoProyecto entity);
        Task<bool> DeleteEntity(TipoProyecto entity);
        Task<List<TipoProyecto>> GetEntities();
        Task<TipoProyecto> GetEntity(int idEntity);
        Task<TipoProyecto> UpdateEntity(TipoProyecto entity);
    }
}
