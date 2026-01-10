using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface IActividadEconomicaRepository
    {
        Task<ActividadEconomica> CreateEntity(ActividadEconomica entity);
        Task<bool> DeleteEntity(ActividadEconomica entity);
        Task<List<ActividadEconomica>> GetEntities();
        Task<ActividadEconomica> GetEntity(int idEntity);
        Task<ActividadEconomica> UpdateEntity(ActividadEconomica entity);
    }
}
