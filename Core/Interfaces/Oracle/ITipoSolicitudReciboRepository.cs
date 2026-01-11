namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoSolicitudReciboRepository
    {
        Task<CregTipoSolicitudRecibo> CreateEntity(CregTipoSolicitudRecibo entity);
        Task<bool> DeleteEntity(CregTipoSolicitudRecibo entity);
        Task<List<CregTipoSolicitudRecibo>> GetEntities();
        Task<CregTipoSolicitudRecibo> GetEntity(int idEntity);
        Task<CregTipoSolicitudRecibo> UpdateEntity(CregTipoSolicitudRecibo entity);
    }
}
