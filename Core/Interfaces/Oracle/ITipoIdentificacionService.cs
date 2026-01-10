namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoIdentificacionService
    {
        Task<CregTipoIdentificacion> CreateEntity(CregTipoIdentificacion entity);
        Task<bool> DeleteEntity(CregTipoIdentificacion entity);
        Task<List<CregTipoIdentificacion>> GetEntities();
        Task<CregTipoIdentificacion> GetEntity(int idEntity);
        Task<CregTipoIdentificacion> UpdateEntity(CregTipoIdentificacion entity);
    }
}
