namespace Core.Interfaces.Oracle
{
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.Oracle;
    public interface ISolServicioConexionService
    {
        Task<Creg075ServicioConexion> GetEntity(int idEntity, int Empresa);
        Task<SolServicioConexionParamsIni> GetParametrosIniciales();
    }
}
