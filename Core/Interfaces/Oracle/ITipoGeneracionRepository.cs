using Core.Entities.Oracle;

namespace Core.Interfaces.Oracle
{
    public interface ITipoGeneracionRepository
    {
        Task<CregTipoGeneracion> CreateEntity(CregTipoGeneracion entity);
        Task<bool> DeleteEntity(CregTipoGeneracion entity);
        Task<List<CregTipoGeneracion>> GetEntities();
        Task<CregTipoGeneracion> GetEntity(int idEntity);
        Task<CregTipoGeneracion> UpdateEntity(CregTipoGeneracion entity);
    }
}
