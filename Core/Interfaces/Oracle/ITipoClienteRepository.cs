namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoClienteRepository
    {
        Task<CregTipoCliente> CreateEntity(CregTipoCliente entity);
        Task<bool> DeleteEntity(CregTipoCliente entity);
        Task<List<CregTipoCliente>> GetEntities();
        Task<CregTipoCliente> GetEntity(int idEntity);
        Task<CregTipoCliente> UpdateEntity(CregTipoCliente entity);
    }
}
