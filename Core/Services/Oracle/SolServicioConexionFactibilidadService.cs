namespace Core.Services.Oracle
{
    using Core.CustomEntities;
    using Core.CustomEntities.Oracle;
    using Core.Entities.Oracle;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.ModelResponse;
    using Core.Options;
    using Core.QueryFilters;
    using Microsoft.Extensions.Options;
    using System.Linq.Expressions;

    public class SolServicioConexionFactibilidadService : ISolServicioConexionFactibilidadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;
        private List<Creg075FactibilidadAnexo> ListDocuments = new List<Creg075FactibilidadAnexo>();
        private Creg075Factibilidad Entity = null!;
        //private readonly ISolServicioConexionReviewsService _solServicioConexionReviewsService = solServicioConexionReviewsService;

        public SolServicioConexionFactibilidadService(IUnitOfWork unitOfWork, IOptions<PathOptions> pathOptions)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
        }

        public async Task<Creg075Factibilidad> GetEntityByIdSolicitud(long idEntity, int empresa)
        {
            Creg075Factibilidad result = new();

            int idSol = (int)idEntity;

            var solicitud = await _unitOfWork.SolServicioConexionRepository.GetEntity(idSol, empresa)
                ?? throw new BusinessException("Solicitud inexistente");

            Expression<Func<Creg075Factibilidad, object>>[] includes =
            {
                x => x.Creg075ServicioConexion,
                x => x.Creg075FactibilidadAnexo,
                x => x.Creg075FactibilidadDetCuen,
                x => x.Creg075FactibilidadObs,
                x => x.Creg075FactibilidadProye,
                x => x.Creg075FactibilidadDocu
            };

            var entity = await GetEntityWithDependences(idEntity, includes);

            if (entity == null)
            {
                result.Cod075Conexion = idSol;
                result.Creg075ServicioConexion = solicitud;
            }
            else
            {
                result = entity;
            }

            return result;
        }

        public async Task<Creg075Factibilidad> GetEntityWithDependences(long idCodServicioConexion, params Expression<Func<Creg075Factibilidad, object>>[] includeObjectProperties)
        {
            return (await _unitOfWork.SolServicioConexionFactibilidadRepository.GetAll(
                filter: x => x.Cod075Conexion == idCodServicioConexion, includeObjectProperties: includeObjectProperties)
            ).FirstOrDefault();
        }

        //public async Task<List<Creg075Factibilidad>> GetAllAsync(Expression<Func<Creg075Factibilidad, bool>> filter = null, Func<IQueryable<Creg075Factibilidad>, IOrderedQueryable<Creg075Factibilidad>>? orderBy = null, bool isTracking = false, params Expression<Func<SolServicioConexionFactibilidad, object>>[] includeObjectProperties)
        //{
        //    return await _unitOfWork.SolServicioConexionFactibilidadRepository.GetAllAsync(filter, orderBy, isTracking, includeObjectProperties);
        //}
       
    }
}
