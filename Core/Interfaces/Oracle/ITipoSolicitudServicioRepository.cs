namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle; 
    public interface ITipoSolicitudServicioRepository
    {
        Task<CregTipoSolicitudServicio> CreateEntity(CregTipoSolicitudServicio entity);
        Task<bool> DeleteEntity(CregTipoSolicitudServicio entity);
        Task<List<CregTipoSolicitudServicio>> GetEntities();
        Task<CregTipoSolicitudServicio> GetEntity(int idEntity);
        Task<CregTipoSolicitudServicio> UpdateEntity(CregTipoSolicitudServicio entity);
    }
}
