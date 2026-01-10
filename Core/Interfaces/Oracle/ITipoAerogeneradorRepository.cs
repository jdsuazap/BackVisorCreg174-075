namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle; 
    public interface ITipoAerogeneradorRepository
    {
        Task<CregTipoAerogenerador> CreateEntity(CregTipoAerogenerador entity);
        Task<bool> DeleteEntity(CregTipoAerogenerador entity);
        Task<List<CregTipoAerogenerador>> GetEntities();
        Task<CregTipoAerogenerador> GetEntity(int idEntity);
        Task<CregTipoAerogenerador> UpdateEntity(CregTipoAerogenerador entity);
    }
}
