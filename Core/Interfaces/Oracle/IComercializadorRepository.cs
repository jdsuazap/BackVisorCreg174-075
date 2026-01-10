namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface IComercializadorRepository
    {
        Task<CregComercializador> CreateEntity(CregComercializador entity);
        Task<bool> DeleteEntity(CregComercializador entity);
        Task<List<CregComercializador>> GetEntities();
        Task<CregComercializador> GetEntity(int idEntity);
        Task<CregComercializador> UpdateEntity(CregComercializador entity);
    }
}
