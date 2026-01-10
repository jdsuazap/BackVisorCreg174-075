namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoPersonaRepository
    {
        Task<CregTipoPersona> CreateEntity(CregTipoPersona entity);
        Task<bool> DeleteEntity(CregTipoPersona entity);
        Task<List<CregTipoPersona>> GetEntities();
        Task<CregTipoPersona> GetEntity(int idEntity);
        Task<CregTipoPersona> UpdateEntity(CregTipoPersona entity);
    }
}
