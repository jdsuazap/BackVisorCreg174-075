using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ISolConexionAutogenComentarioRepository
    {
        Task<List<SolConexionAutogenComentario>> GetEntitiesByRequest(int idRequest);
    }
}
