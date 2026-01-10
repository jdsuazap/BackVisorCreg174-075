namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoProyectoRepository
    {
        Task<CregTipoProyecto> CreateEntity(CregTipoProyecto entity);
        Task<bool> DeleteEntity(CregTipoProyecto entity);
        Task<List<CregTipoProyecto>> GetEntities();
        Task<CregTipoProyecto> GetEntity(int idEntity);
        Task<CregTipoProyecto> UpdateEntity(CregTipoProyecto entity);
    }
}
