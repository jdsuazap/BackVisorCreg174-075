using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoZonaService
    {
        Task<TipoZona> CreateEntity(TipoZona entity);
        Task<bool> DeleteEntity(TipoZona entity);
        Task<List<TipoZona>> GetEntities();
        Task<TipoZona> GetEntity(int idEntity);
        Task<TipoZona> UpdateEntity(TipoZona entity);
    }
}
