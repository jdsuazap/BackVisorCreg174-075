using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoTecnologiaRepository
    {
        Task<TipoTecnologia> CreateEntity(TipoTecnologia entity);
        Task<bool> DeleteEntity(TipoTecnologia entity);
        Task<List<TipoTecnologia>> GetEntities();
        Task<TipoTecnologia> GetEntity(int idEntity);
        Task<TipoTecnologia> UpdateEntity(TipoTecnologia entity);
    }
}
