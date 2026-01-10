namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoConstruccionService
    {
        Task<CregTipoConstruccion> CreateEntity(CregTipoConstruccion entity);
        Task<bool> DeleteEntity(CregTipoConstruccion entity);
        Task<List<CregTipoConstruccion>> GetEntities();
        Task<CregTipoConstruccion> GetEntity(int idTipoConstruccion);
        Task<CregTipoConstruccion> UpdateEntity(CregTipoConstruccion entity);
    }
}
