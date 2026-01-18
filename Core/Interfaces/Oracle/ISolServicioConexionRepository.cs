namespace Core.Interfaces.Oracle
{
    using Core.CustomEntities.Parametros;
    using Core.Entities.Oracle;
    using System.Linq.Expressions;
    public interface ISolServicioConexionRepository
    {
        Task<Creg075ServicioConexion> GetEntity(int idEntity, int Empresa);
        Task<List<Creg075Anexo>> GetAnexosBySolicitud(int idEntity);
        Task<List<Creg075DetallesCuenta>> GetDetalleCuentaBySolicitud(int idEntity);
        //Task<List<PasosSolServicioConexion>> GetPasosBySolicitud(int idEntity);
        //Task<List<PasosSolServicioConexion>> GetPasosByRadicado(string numRadicado);


        Task<List<Creg075ServicioConexion>> GetAll(
                                        Expression<Func<Creg075ServicioConexion, bool>> filter = null,
                                        Func<IQueryable<Creg075ServicioConexion>, IOrderedQueryable<Creg075ServicioConexion>>? orderBy = null,
                                        Func<IQueryable<Creg075ServicioConexion>, IOrderedQueryable<Creg075ServicioConexion>>? orderByDescending = null,
                                        bool isTracking = false,
                                        params Expression<Func<Creg075ServicioConexion, object>>[] includeObjectProperties);

    }
}
