using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoPersonaService
    {
        Task<TipoPersona> CreateEntity(TipoPersona entity);
        Task<bool> DeleteEntity(TipoPersona entity);
        Task<List<TipoPersona>> GetEntities();
        Task<TipoPersona> GetEntity(int idEntity);
        Task<TipoPersona> UpdateEntity(TipoPersona entity);
    }
}
