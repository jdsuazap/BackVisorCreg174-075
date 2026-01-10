namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.ModelResponse;
    using System.Linq.Expressions;

    public interface ISolServicioConexionFactibilidadService
    {
        Task<ResponseAction> FactibilidadOtorgadaReview(bool isApproved, SolServicioConexion entity, SolServicioConexionReview review);
        Task<List<SolServicioConexionFactibilidad>> GetEntities();
        Task<SolServicioConexionFactibilidad> GetEntity(long idEntity);
        Task<SolServicioConexionFactibilidad> GetEntityByIdSolicitud(long idEntity);       
        Task<SolServicioConexionFactibilidad> GetEntityWithDependences(long idCodServicioConexion, params Expression<Func<SolServicioConexionFactibilidad, object>>[] includeObjectProperties);
    }
}
