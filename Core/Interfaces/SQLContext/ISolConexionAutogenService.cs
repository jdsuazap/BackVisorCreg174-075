namespace Core.Interfaces.SQLContext
{
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.SQLContext;

    public interface ISolConexionAutogenService
    {
        Task<SolConexionAutogen> GetEntity(SolConexionAutogen entity);
        Task<SolConexionAutogenParamsIni> GetParametrosIniciales();
    }
}
