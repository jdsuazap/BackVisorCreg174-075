using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface IEstadoService
    {
        Task<Estado> CreateEntity(Estado entity);
        Task<bool> DeleteEntity(Estado entity);
        Task<List<Estado>> GetEntities();
        Task<List<Estado>> GetEntitiesByIdTipoEstado(int idTipoEstado);
        Task<Estado> GetEntity(int idEntity);
        Task<Estado> UpdateEntity(Estado entity);
    }
}
