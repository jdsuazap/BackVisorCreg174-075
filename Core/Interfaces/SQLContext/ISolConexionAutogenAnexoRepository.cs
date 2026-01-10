namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;

    public interface ISolConexionAutogenAnexoRepository
    {
        Task<SolConexionAutogenAnexo> CreateEntity(SolConexionAutogenAnexo entity);
        Task<List<SolConexionAutogenAnexo>> CreateEntity_Range(List<SolConexionAutogenAnexo> entity);
        Task<bool> DeleteEntity(SolConexionAutogenAnexo entity);
        Task<List<SolConexionAutogenAnexo>> GetEntities();
        Task<List<SolConexionAutogenAnexo>> GetEntitiesByCodSolConexionAutogen(int codSolicitud);
        Task<SolConexionAutogenAnexo> GetEntity(int idEntity);
        Task<SolConexionAutogenAnexo> UpdateEntity(SolConexionAutogenAnexo entity);
    }
}
