namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;

    public interface IDepartamentoRepository
    {
        Task<CregDepartamento> CreateEntity(CregDepartamento entity);
        Task<bool> DeleteEntity(CregDepartamento entity);
        Task<List<CregDepartamento>> GetEntities();
        Task<CregDepartamento> GetEntity(string idEntity);
        Task<CregDepartamento> UpdateEntity(CregDepartamento entity);
    }
}
