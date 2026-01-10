using Core.Entities.SQLContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionDisenioRepository
    {
        Task<List<SolServicioConexionDisenio>> GetEntities();
        Task<SolServicioConexionDisenio> GetEntity(long idEntity);
        Task<SolServicioConexionDisenio> CreateEntity(SolServicioConexionDisenio entity);
        Task<SolServicioConexionDisenio> UpdateEntity(SolServicioConexionDisenio entity);
        Task<bool> DeleteEntity(SolServicioConexionDisenio entity);
        Task<List<SolServicioConexionDisenio>> GetAllAsync(Expression<Func<SolServicioConexionDisenio, bool>> filter = null,
                                                                Func<IQueryable<SolServicioConexionDisenio>, IOrderedQueryable<SolServicioConexionDisenio>>? orderBy = null,
                                                                bool isTracking = false, params Expression<Func<SolServicioConexionDisenio, object>>[] includeObjectProperties);
    }
}
