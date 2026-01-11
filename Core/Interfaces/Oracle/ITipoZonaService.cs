namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoZonaService
    {
        Task<CregTipoZona> CreateEntity(CregTipoZona entity);
        Task<bool> DeleteEntity(CregTipoZona entity);
        Task<List<CregTipoZona>> GetEntities();
        Task<CregTipoZona> GetEntity(int idEntity);
        Task<CregTipoZona> UpdateEntity(CregTipoZona entity);
    }
}
