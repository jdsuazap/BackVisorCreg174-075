namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;

    public interface ISolServicioConexionReciboTecnicoService
    {
        Task<List<SolServicioConexionReciboTecnico>> GetEntities();
    }
}
