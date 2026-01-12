namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface IPersonaAutorizaReciboRepository
    {
        Task<CregPersonaAutoriza> CreateEntity(CregPersonaAutoriza entity);
        Task<bool> DeleteEntity(CregPersonaAutoriza entity);
        Task<List<CregPersonaAutoriza>> GetEntities();
        Task<CregPersonaAutoriza> GetEntity(int idEntity);
        Task<CregPersonaAutoriza> UpdateEntity(CregPersonaAutoriza entity);
    }
}
