namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle; 
    public interface IActividadEconomicaRepository
    {
        Task<CregActividadEconomica> CreateEntity(CregActividadEconomica entity);
        Task<bool> DeleteEntity(CregActividadEconomica entity);
        Task<List<CregActividadEconomica>> GetEntities();
        Task<CregActividadEconomica> GetEntity(int idEntity);
        Task<CregActividadEconomica> UpdateEntity(CregActividadEconomica entity);
    }
}
