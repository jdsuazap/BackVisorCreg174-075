namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    using System.Linq.Expressions;

    public interface ISolServicioConexionReciboTecnicoRepository
    {
        Task<List<Creg075ReciboTecnico>> GetEntities();
        Task<Creg075ReciboTecnico> GetEntity(int idEntity);                
        Task<List<Creg075ReciboTecnico>> GetAll(
           Expression<Func<Creg075ReciboTecnico, bool>> filter = null,
           Func<IQueryable<Creg075ReciboTecnico>, IOrderedQueryable<Creg075ReciboTecnico>> orderBy = null,
           Func<IQueryable<Creg075ReciboTecnico>, IOrderedQueryable<Creg075ReciboTecnico>> orderByDescending = null,
           bool isTracking = false,
           params Expression<Func<Creg075ReciboTecnico, object>>[] includeObjectProperties);
    }
}
