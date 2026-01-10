using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface IClasificacionProyectoRepository
    {
        Task<ClasificacionProyecto> CreateEntity(ClasificacionProyecto entity);
        Task<bool> DeleteEntity(ClasificacionProyecto entity);
        Task<List<ClasificacionProyecto>> GetEntities();
        Task<ClasificacionProyecto> GetEntity(int idEntity);
        Task<ClasificacionProyecto> UpdateEntity(ClasificacionProyecto entity);
    }
}
