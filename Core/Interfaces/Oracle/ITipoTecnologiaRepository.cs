namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoTecnologiaRepository
    {
        Task<CregTipoTecnologia> CreateEntity(CregTipoTecnologia entity);
        Task<bool> DeleteEntity(CregTipoTecnologia entity);
        Task<List<CregTipoTecnologia>> GetEntities();
        Task<CregTipoTecnologia> GetEntity(int idEntity);
        Task<CregTipoTecnologia> UpdateEntity(CregTipoTecnologia entity);
    }
}
