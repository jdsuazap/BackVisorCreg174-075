using Core.CustomEntities.Parametros;
using Core.Entities.SQLContext;
using System.Linq.Expressions;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionRepository
    {       
        Task<SolServicioConexion> GetEntity(int idEntity);
        Task<List<SolServicioConexionAnexo>> GetAnexosBySolicitud(int idEntity);
        Task<List<SolServicioConexionDetalleCuenta>> GetDetalleCuentaBySolicitud(int idEntity);
        Task<List<PasosSolServicioConexion>> GetPasosBySolicitud(int idEntity);
        Task<List<PasosSolServicioConexion>> GetPasosByRadicado(string numRadicado);
       

        Task<List<SolServicioConexion>> GetAll(
                                        Expression<Func<SolServicioConexion, bool>> filter = null,
                                        Func<IQueryable<SolServicioConexion>, IOrderedQueryable<SolServicioConexion>>? orderBy = null,
                                        Func<IQueryable<SolServicioConexion>, IOrderedQueryable<SolServicioConexion>>? orderByDescending = null,
                                        bool isTracking = false,
                                        params Expression<Func<SolServicioConexion, object>>[] includeObjectProperties);

    }
}
