namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface IClasificacionProyectoService
    {
        Task<CregClasificacionProyecto> CreateEntity(CregClasificacionProyecto entity);
        Task<bool> DeleteEntity(CregClasificacionProyecto entity);
        Task<List<CregClasificacionProyecto>> GetEntities();
        Task<CregClasificacionProyecto> GetEntity(int idEntity);
        Task<CregClasificacionProyecto> UpdateEntity(CregClasificacionProyecto entity);
    }
}
