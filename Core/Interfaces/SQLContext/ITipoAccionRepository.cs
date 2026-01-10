using Core.Entities.SQLContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoAccionRepository
    {
        Task<List<TipoAccion>> GetEntities();
        Task<TipoAccion> GetEntity(int idEntity);
        Task<TipoAccion> CreateEntity(TipoAccion entity);
        Task<TipoAccion> UpdateEntity(TipoAccion entity);
        Task<bool> DeleteEntity(TipoAccion entity);
    }
}
