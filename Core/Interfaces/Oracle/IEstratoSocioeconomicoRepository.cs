
namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface IEstratoSocioeconomicoRepository
    {
        Task<CregEstratoSocioeconomico> CreateEntity(CregEstratoSocioeconomico entity);
        Task<bool> DeleteEntity(CregEstratoSocioeconomico entity);
        Task<List<CregEstratoSocioeconomico>> GetEntities();
        Task<CregEstratoSocioeconomico> GetEntity(int idEntity);
        Task<CregEstratoSocioeconomico> UpdateEntity(CregEstratoSocioeconomico entity);
    }
}
