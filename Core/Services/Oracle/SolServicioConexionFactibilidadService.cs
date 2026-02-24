namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Options;
    using Microsoft.Extensions.Options;
    using System.Linq.Expressions;

    public class SolServicioConexionFactibilidadService : ISolServicioConexionFactibilidadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;
        private List<Creg075FactibilidadAnexo> ListDocuments = new List<Creg075FactibilidadAnexo>();
        private Creg075Factibilidad Entity = null!;

        public SolServicioConexionFactibilidadService(IUnitOfWork unitOfWork, IOptions<PathOptions> pathOptions)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
        }

        public async Task<Creg075Factibilidad> GetEntityByIdSolicitud(long Id, long idEntity, int empresa)
        {
            Creg075Factibilidad result = new();

            var solicitud = await _unitOfWork.SolServicioConexionRepository.GetEntity((int)idEntity, empresa)
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

            var entity = await GetEntityWithDependences(Id, includes);

            if (entity == null)
            {
                result.Cod075Conexion = (int)Id;
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
    }
}
