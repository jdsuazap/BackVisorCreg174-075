namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;

    public interface IActividadEconomicaService
    {
        Task<ActividadEconomica> CreateEntity(ActividadEconomica entity);
        Task<bool> DeleteEntity(ActividadEconomica entity);
        Task<List<ActividadEconomica>> GetEntities();
        Task<ActividadEconomica> GetEntity(int idEntity);
        Task<ActividadEconomica> UpdateEntity(ActividadEconomica entity);
    }
}
