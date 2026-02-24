namespace Core.Services.Oracle
{
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.Oracle;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Options;
    using Microsoft.Extensions.Options;

    public class SolServicioConexionService : ISolServicioConexionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;
        private Creg075ServicioConexion _entity = null!;

        public SolServicioConexionService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
        }

        public async Task<Creg075ServicioConexion> GetEntity(int idEntity, int Empresa)
        {
            var solicitud = await _unitOfWork.SolServicioConexionRepository.GetEntity(idEntity, Empresa);
            if (solicitud == null)
            {
                throw new BusinessException("Solicitud Inexistente");
            }

            solicitud.Creg075Anexos = await GetAnexosBySolicitud(idEntity);
            solicitud.Creg075DetallesCuentas = await GetDetalleCuentaBySolicitud(idEntity);
            solicitud.Creg075Pasos = await GetPasosBySolicitud(idEntity);
            return solicitud;
        }

        public async Task<List<Creg075Anexo>> GetAnexosBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolServicioConexionRepository.GetAnexosBySolicitud(idEntity);
        }

        public async Task<List<Creg075DetallesCuenta>> GetDetalleCuentaBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolServicioConexionRepository.GetDetalleCuentaBySolicitud(idEntity);
        }

        public async Task<List<Creg075Pasos>> GetPasosBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolServicioConexionRepository.GetPasosBySolicitud(idEntity);
        }

        //public async Task<List<PasosSolServicioConexion>> GetPasosByRadicado(string numRadicado)
        //{
        //    return await _unitOfWork.SolServicioConexionRepository.GetPasosByRadicado(numRadicado);
        //}       

        public async Task<SolServicioConexionParamsIni> GetParametrosIniciales()
        {
            return new SolServicioConexionParamsIni()
            {
                ListadoActividadEconomica = await _unitOfWork.ActividadEconomicaRepository.GetEntities(),
                ListadoEstratoSocioeconomico = await _unitOfWork.EstratoSocioeconomicoRepository.GetEntities(),
                ListadoPersonaAutorizaRecibo = await _unitOfWork.PersonaAutorizaReciboRepository.GetEntities(),
                ListadoTipoClaseCarga = await _unitOfWork.TipoClaseCargaRepository.GetEntities(),
                ListadoTipoCliente = await _unitOfWork.TipoClienteRepository.GetEntities(),
                ListadoTipoCompletitud = await _unitOfWork.TipoCompletitudRepository.GetEntities(),
                ListadoTipoConexion = await _unitOfWork.TipoConexionRepository.GetEntities(),
                ListadoTipoConstruccion = await _unitOfWork.TipoConstruccionRepository.GetEntities(),
                ListadoTipoIdentificacion = await _unitOfWork.TipoIdentificacionRepository.GetEntities(),
                ListadoTipoPersona = await _unitOfWork.TipoPersonaRepository.GetEntities(),
                ListadoTipoProyecto = await _unitOfWork.TipoProyectoRepository.GetEntities(),
                ListadoTipoServicio = await _unitOfWork.TipoServicioRepository.GetEntities(),
                ListadoTipoSolicitudRecibo = await _unitOfWork.TipoSolicitudReciboRepository.GetEntities(),
                ListadoTipoSolicitudServicio = await _unitOfWork.TipoSolicitudServicioRepository.GetEntities(),
                ListadoTipoTension = await _unitOfWork.TipoTensionRepository.GetEntities(),
                ListadoTipoZona = await _unitOfWork.TipoZonaRepository.GetEntities(),
                ListadoDocumentosXformularios = await _unitOfWork.DocumentosXformularioRepository.GetEntitiesByCodFormulario((int)FormularioPrincipalEnum.Solicitud_Conexion_Servicio),
                ListadoComercializador = await _unitOfWork.ComercializadorRepository.GetEntities(),
            };
        }
    }
}
