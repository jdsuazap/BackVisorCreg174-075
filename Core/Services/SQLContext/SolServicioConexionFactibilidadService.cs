namespace Core.Services.SQLContext
{
    using Core.CustomEntities.SQLContext;
    using Core.Entities.SQLContext;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;
    using Core.ModelResponse;
    using Core.Options;
    using Microsoft.Extensions.Options;
    using System.Linq.Expressions;

    public class SolServicioConexionFactibilidadService
    : ISolServicioConexionFactibilidadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;
        private readonly ISolServicioConexionReviewsService _solServicioConexionReviewsService;

        private SolServicioConexionFactibilidad _entity = null!;

        public SolServicioConexionFactibilidadService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions,
            ISolServicioConexionReviewsService solServicioConexionReviewsService)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
            _solServicioConexionReviewsService = solServicioConexionReviewsService;
        }

        public async Task<ResponseAction> FactibilidadOtorgadaReview(bool isApproved, SolServicioConexion entity, SolServicioConexionReview review)
        {
            ReviewInput reviewInput = new();

            var disenio = (
                await _unitOfWork.SolServicioConexionDisenioRepository.GetAllAsync(
                    x => x.CodServicioConexion == review.CodSolServicioConexion &&
                    x.Estado.HasValue && 
                    x.Estado.Value
                )
            ).FirstOrDefault();

            review.CodEstado = entity.CodEstado;
            review.Etapa = entity.Etapa;
            review.ProcedimientoOrigen = nameof(FactibilidadOtorgadaReview);
            review.Aprobado = isApproved;
            review.Descripcion = $"Se realiza {nameof(FactibilidadOtorgadaReview)} para la solicitud {entity.NumeroRadicado} que esta en el estado {(EstadosEnum)entity.CodEstado}";

            entity.AnulacionHabilitada = true;

            if (disenio != null)
            {
                review.CodDisenio = disenio.Id;
            }

            reviewInput = new ReviewInput
            {
                Entity = review,
                ApprovedStatus = EstadosEnum.Creg_075_Factibilidad_servicio_otorgada,
                RejectedStatus = EstadosEnum.Creg_075_Factibilidad_servicio_otorgada,
                AnexosPath = _pathOptions.Folder_Archivos_FactibilidadCreg075,
                CorreoEnum = new List<CorreosEnum> { CorreosEnum.Notificacion_Creg075 },
                HasCuerpoCorreo = true,
                CuerpoCorreo = CuerpoCorreoEnum.Creg075_Notificacion_Factibilidad_Servicio_Otorgada,
                EmailMessage = review.Descripcion,
                ApprovedMessage = SubsanationStatusMessage.ApprovedMessage,
                RejectedMessage = SubsanationStatusMessage.RejectedMessage,
                ScheduleMailType = ScheduleMailEnum.SendWithTemplate
            };

            return await _solServicioConexionReviewsService.ReviewAsync(reviewInput, entity, useTransaction: false);
        }

        public async Task<List<SolServicioConexionFactibilidad>> GetEntities()
        {
            return await _unitOfWork.SolServicioConexionFactibilidadRepository.GetEntities();
        }

        public async Task<SolServicioConexionFactibilidad> GetEntity(long idEntity)
        {
            return await _unitOfWork.SolServicioConexionFactibilidadRepository.GetEntity(idEntity);
        }

        public async Task<SolServicioConexionFactibilidad> GetEntityByIdSolicitud(long idEntity, int Empresa)
        {
            SolServicioConexionFactibilidad result = new();

            int idSol = (int)idEntity;

            var solicitud = await _unitOfWork.SolServicioConexionRepository.GetEntity(idSol, Empresa)
                ?? throw new BusinessException("Solicitud inexistente");

            Expression<Func<SolServicioConexionFactibilidad, object>>[] includes = {
                x => x.CodSolServicioConexionNavigation,
                //x => x.SolServicioConexionFactibilidadAnexos,
                //x => x.SolServicioConexionFactibilidadDetalleCuentas,
                //x => x.SolServicioConexionFactibilidadObservaciones,
                //x => x.SolServicioConexionFactibilidadPorProyectos,
                //x => x.SolServicioConexionFactibilidadPorDocumentos
            };

            var entity = await GetEntityWithDependences(idEntity, includes);

            if (entity == null)
            {
                result.CodSolServicioConexion = idSol;
                //result.CodSolServicioConexionNavigation = solicitud;
            }
            else
            {
                result = entity;
            }

            return result;
        }

        public async Task<SolServicioConexionFactibilidad> GetEntityWithDependences(long idCodServicioConexion, params Expression<Func<SolServicioConexionFactibilidad, object>>[] includeObjectProperties)
        {
            return (await _unitOfWork.SolServicioConexionFactibilidadRepository.GetAllAsync(
                filter: x => x.CodSolServicioConexion == idCodServicioConexion, includeObjectProperties: includeObjectProperties)
            ).FirstOrDefault();
        }
    }
}
