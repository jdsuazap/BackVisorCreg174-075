using Core.Entities.SQLContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoActivoService
    {
        Task<TipoActivo> CreateEntity(TipoActivo entity);
        Task<bool> DeleteEntity(TipoActivo entity);
        Task<List<TipoActivo>> GetEntities();
        Task<TipoActivo> GetEntity(string idEntity);
        Task<TipoActivo> UpdateEntity(TipoActivo entity);
    }
}
