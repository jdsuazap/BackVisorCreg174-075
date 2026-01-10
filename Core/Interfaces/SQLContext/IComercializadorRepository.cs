using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface IComercializadorRepository
    {
        Task<Comercializador> CreateEntity(Comercializador entity);
        Task<bool> DeleteEntity(Comercializador entity);
        Task<List<Comercializador>> GetEntities();
        Task<Comercializador> GetEntity(int idEntity);
        Task<Comercializador> UpdateEntity(Comercializador entity);
    }
}
