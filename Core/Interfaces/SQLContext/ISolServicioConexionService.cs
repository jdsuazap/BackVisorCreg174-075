namespace Core.Interfaces.SQLContext
{
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.SQLContext;
    public interface ISolServicioConexionService
    {
        Task<SolServicioConexion> GetEntity(int idEntity);
        Task<SolServicioConexionParamsIni> GetParametrosIniciales();
    }
}
