namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface IEstadoService
    {
        Task<CregEstado> CreateEntity(CregEstado entity);
        Task<bool> DeleteEntity(CregEstado entity);
        Task<List<CregEstado>> GetEntities();
        Task<List<CregEstado>> GetEntitiesByIdTipoEstado(int idTipoEstado);
        Task<CregEstado> GetEntity(int idEntity);
        Task<CregEstado> UpdateEntity(CregEstado entity);
    }
}
