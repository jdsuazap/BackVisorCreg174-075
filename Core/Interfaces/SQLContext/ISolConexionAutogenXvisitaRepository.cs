using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ISolConexionAutogenXvisitaRepository : IRepository<SolConexionAutogenXvisita>
    {
        Task<SolConexionAutogenXvisita> CreateEntity(SolConexionAutogenXvisita entity);
        Task<bool> DeleteEntity(SolConexionAutogenXvisita entity);
        Task<List<SolConexionAutogenXvisita>> GetEntities();
        Task<SolConexionAutogenXvisita> GetEntity(int idEntity);
        Task<SolConexionAutogenXvisita> UpdateEntity(SolConexionAutogenXvisita entity);
    }
}
