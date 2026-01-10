namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;

    public interface ISolServicioConexionComentarioService
    {
        Task<List<SolServicioConexionComentario>> GetEntitiesByRequest(int idRequest);
    }
}
