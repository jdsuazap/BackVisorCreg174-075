using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoConstruccionService
    {
        Task<TipoConstruccion> CreateEntity(TipoConstruccion entity);
        Task<bool> DeleteEntity(TipoConstruccion entity);
        Task<List<TipoConstruccion>> GetEntities();
        Task<TipoConstruccion> GetEntity(int idTipoConstruccion);
        Task<TipoConstruccion> UpdateEntity(TipoConstruccion entity);
    }
}
