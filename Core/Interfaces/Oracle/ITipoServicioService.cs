namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoServicioService
    {
        Task<CregTipoServicio> CreateEntity(CregTipoServicio entity);
        Task<bool> DeleteEntity(CregTipoServicio entity);
        Task<List<CregTipoServicio>> GetEntities();
        Task<CregTipoServicio> GetEntity(int idEntity);
        Task<CregTipoServicio> UpdateEntity(CregTipoServicio entity);
    }
}
