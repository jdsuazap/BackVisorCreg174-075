namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoTensionService
    {
        Task<CregTipoTension> CreateEntity(CregTipoTension entity);
        Task<bool> DeleteEntity(CregTipoTension entity);
        Task<List<CregTipoTension>> GetEntities();
        Task<CregTipoTension> GetEntity(int idEntity);
        Task<CregTipoTension> UpdateEntity(CregTipoTension entity);
    }
}
