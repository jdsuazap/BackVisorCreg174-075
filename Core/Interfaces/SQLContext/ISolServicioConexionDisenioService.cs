namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;
    using System.Linq.Expressions;
    public interface ISolServicioConexionDisenioService
    {
        Task<List<SolServicioConexionDisenio>> GetAllAsync(Expression<Func<SolServicioConexionDisenio, bool>> filter = null,
                                                                Func<IQueryable<SolServicioConexionDisenio>, IOrderedQueryable<SolServicioConexionDisenio>>? orderBy = null,
                                                                bool isTracking = false, params Expression<Func<SolServicioConexionDisenio, object>>[] includeObjectProperties);
    }
}
