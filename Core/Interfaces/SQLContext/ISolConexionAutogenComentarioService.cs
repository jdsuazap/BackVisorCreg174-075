using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ISolConexionAutogenComentarioService
    {
        Task<List<SolConexionAutogenComentario>> GetEntitiesByRequest(int idRequest);
    }
}
