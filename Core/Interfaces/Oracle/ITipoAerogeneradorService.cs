namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoAerogeneradorService
    {
        Task<CregTipoAerogenerador> CreateEntity(CregTipoAerogenerador entity);
        Task<bool> DeleteEntity(CregTipoAerogenerador entity);
        Task<List<CregTipoAerogenerador>> GetEntities();
        Task<CregTipoAerogenerador> GetEntity(int idEntity);
        Task<CregTipoAerogenerador> UpdateEntity(CregTipoAerogenerador entity);
    }
}
