namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    using System.Linq.Expressions;

    public interface ISolServicioConexionDisenioService
    {      
        Task<List<Creg075Disenio>> GetAll(Expression<Func<Creg075Disenio, bool>> filter = null,
                                                                Func<IQueryable<Creg075Disenio>, IOrderedQueryable<Creg075Disenio>>? orderBy = null,
                                                                bool isTracking = false, params Expression<Func<Creg075Disenio, object>>[] includeObjectProperties);

    }
}
