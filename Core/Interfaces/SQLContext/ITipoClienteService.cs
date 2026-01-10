using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoClienteService
    {
        Task<TipoCliente> CreateEntity(TipoCliente entity);
        Task<bool> DeleteEntity(TipoCliente entity);
        Task<List<TipoCliente>> GetEntities();
        Task<TipoCliente> GetEntity(int idEntity);
        Task<TipoCliente> UpdateEntity(TipoCliente entity);
    }
}
