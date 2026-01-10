using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface IEstratoSocioeconomicoRepository
    {
        Task<EstratoSocioeconomico> CreateEntity(EstratoSocioeconomico entity);
        Task<bool> DeleteEntity(EstratoSocioeconomico entity);
        Task<List<EstratoSocioeconomico>> GetEntities();
        Task<EstratoSocioeconomico> GetEntity(int idEntity);
        Task<EstratoSocioeconomico> UpdateEntity(EstratoSocioeconomico entity);
    }
}
