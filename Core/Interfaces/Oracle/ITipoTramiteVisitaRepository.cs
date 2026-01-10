namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoTramiteVisitaRepository
    {
        Task<CregTipoTramiteVisita> CreateEntity(CregTipoTramiteVisita entity);
        Task<bool> DeleteEntity(CregTipoTramiteVisita entity);
        Task<List<CregTipoTramiteVisita>> GetEntities();
        Task<CregTipoTramiteVisita> GetEntity(int idEntity);
        Task<CregTipoTramiteVisita> UpdateEntity(CregTipoTramiteVisita entity);
    }
}
