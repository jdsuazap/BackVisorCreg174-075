namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;

    public interface ICregCiudadRepository
    {
        Task<CregCiudad> CreateEntity(CregCiudad entity);
        Task<bool> DeleteEntity(CregCiudad entity);
        Task<List<CregCiudad>> GetEntities();
        Task<List<CregCiudad>> GetEntitiesByDepartamento(string idEntityDpto);
        Task<CregCiudad> GetEntity(int idEntity);
        Task<CregCiudad> UpdateEntity(CregCiudad entity);
    }
}
