namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoCompletitudRepository
    {
        Task<CregTipoCompletitud> CreateEntity(CregTipoCompletitud entity);
        Task<bool> DeleteEntity(CregTipoCompletitud entity);
        Task<List<CregTipoCompletitud>> GetEntities();
        Task<CregTipoCompletitud> GetEntity(int idEntity);
        Task<CregTipoCompletitud> UpdateEntity(CregTipoCompletitud entity);
    }
}
