namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoConexionRepository
    {
        Task<CregTipoConexion> CreateEntity(CregTipoConexion entity);
        Task<bool> DeleteEntity(CregTipoConexion entity);
        Task<List<CregTipoConexion>> GetEntities();
        Task<CregTipoConexion> GetEntity(int idEntity);
        Task<CregTipoConexion> UpdateEntity(CregTipoConexion entity);
    }
}
