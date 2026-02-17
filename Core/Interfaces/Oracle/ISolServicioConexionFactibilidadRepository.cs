namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    using System.Linq.Expressions;

    public interface ISolServicioConexionFactibilidadRepository
    {        
        Task<Creg075Factibilidad> GetEntity(int idEntity);
        Task<List<Creg075Factibilidad>> GetEntities();

        Task<List<Creg075Factibilidad>> GetAll(
           Expression<Func<Creg075Factibilidad, bool>> filter = null,
           Func<IQueryable<Creg075Factibilidad>, IOrderedQueryable<Creg075Factibilidad>> orderBy = null,
           Func<IQueryable<Creg075Factibilidad>, IOrderedQueryable<Creg075Factibilidad>> orderByDescending = null,
           bool isTracking = false,
           params Expression<Func<Creg075Factibilidad, object>>[] includeObjectProperties);
    }
}
