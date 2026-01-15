namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IPasosSolConexionAutogenRepository
    {
        Task<Creg174Pasos> CreateEntity(Creg174Pasos entity);
        Task<bool> DeleteEntity(Creg174Pasos entity);
        Task<List<Creg174Pasos>> GetEntities();
        Task<Creg174Pasos> GetEntity(int idEntity);
        Task<Creg174Pasos> GetLastEntityBySolConexion(int idSolConexion);
        Task<Creg174Pasos> UpdateEntity(Creg174Pasos entity);
    }
}
