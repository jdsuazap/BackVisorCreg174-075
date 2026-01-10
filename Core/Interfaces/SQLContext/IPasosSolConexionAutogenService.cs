using Core.Entities.SQLContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.SQLContext
{
    public interface IPasosSolConexionAutogenService
    {
        Task<PasosSolConexionAutogen> CreateEntity(PasosSolConexionAutogen entity);
        Task<bool> DeleteEntity(PasosSolConexionAutogen entity);
        Task<List<PasosSolConexionAutogen>> GetEntities();
        Task<PasosSolConexionAutogen> GetEntity(int idEntity);
        Task<PasosSolConexionAutogen> UpdateEntity(PasosSolConexionAutogen entity);
    }
}
