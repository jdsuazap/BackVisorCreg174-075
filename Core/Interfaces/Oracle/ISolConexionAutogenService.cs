namespace Core.Interfaces.Oracle
{
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.Oracle;

    public interface ISolConexionAutogenService
    {
        Task<Creg174Autogen> GetEntity(Creg174Autogen entity);
        Task<SolConexionAutogenParamsIni> GetParametrosIniciales();
    }
}
