namespace Core.Services.SQLContext
{
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.SQLContext;
    using Core.Enumerations;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;
    using Core.Options;
    using Microsoft.Extensions.Options;

    public class SolServicioConexionService : ISolServicioConexionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;
        private SolServicioConexion _entity = null!;

        public SolServicioConexionService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
        }

        public async Task<SolServicioConexion> GetEntity(int idEntity)
        {
            var solicitud = await _unitOfWork.SolServicioConexionRepository.GetEntity(idEntity);

            //solicitud.SolServicioConexionAnexos = await GetAnexosBySolicitud(idEntity);
            solicitud.SolServicioConexionDetalleCuenta = await GetDetalleCuentaBySolicitud(idEntity);
            solicitud.PasosSolServicioConexions = await GetPasosBySolicitud(idEntity);
            //solicitud.SolServicioConexionComentarios = await GetComentarioBySolicitud(idEntity);

            return solicitud;
        }

        public async Task<List<SolServicioConexionAnexo>> GetAnexosBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolServicioConexionRepository.GetAnexosBySolicitud(idEntity);
        }

        public async Task<List<SolServicioConexionDetalleCuenta>> GetDetalleCuentaBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolServicioConexionRepository.GetDetalleCuentaBySolicitud(idEntity);
        }

        public async Task<List<PasosSolServicioConexion>> GetPasosBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolServicioConexionRepository.GetPasosBySolicitud(idEntity);
        }

        public async Task<List<PasosSolServicioConexion>> GetPasosByRadicado(string numRadicado)
        {
            return await _unitOfWork.SolServicioConexionRepository.GetPasosByRadicado(numRadicado);
        }

        //public async Task<List<SolServicioConexionComentario>> GetComentarioBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolServicioConexionRepository.GetComentarioBySolicitud(idEntity);
        //}

        public async Task<SolServicioConexionParamsIni> GetParametrosIniciales()
        {

            //var ListadoActividadEconomica = await _unitOfWork.ActividadEconomicaRepository.GetEntities();
            var ListadoEstratoSocioeconomico = await _unitOfWork.EstratoSocioeconomicoRepository.GetEntities();
            var ListadoPersonaAutorizaRecibo = await _unitOfWork.PersonaAutorizaReciboRepository.GetEntities();
            var ListadoTipoClaseCarga = await _unitOfWork.TipoClaseCargaRepository.GetEntities();
            var ListadoTipoCliente = await _unitOfWork.TipoClienteRepository.GetEntities();
            var ListadoTipoCompletitud = await _unitOfWork.TipoCompletitudRepository.GetEntities();
            var ListadoTipoConexion = await _unitOfWork.TipoConexionRepository.GetEntities();
            var ListadoTipoConstruccion = await _unitOfWork.TipoConstruccionRepository.GetEntities();
            var ListadoTipoIdentificacion = await _unitOfWork.TipoIdentificacionRepository.GetEntities();
            var ListadoTipoPersona = await _unitOfWork.TipoPersonaRepository.GetEntities();
            var ListadoTipoProyecto = await _unitOfWork.TipoProyectoRepository.GetEntities();
            var ListadoTipoServicio = await _unitOfWork.TipoServicioRepository.GetEntities();
            var ListadoTipoSolicitudRecibo = await _unitOfWork.TipoSolicitudReciboRepository.GetEntities();
            var ListadoTipoSolicitudServicio = await _unitOfWork.TipoSolicitudServicioRepository.GetEntities();
            var ListadoTipoTension = await _unitOfWork.TipoTensionRepository.GetEntities();
            var ListadoTipoZona = await _unitOfWork.TipoZonaRepository.GetEntities();
            var ListadoDocumentosXformularios = await _unitOfWork.DocumentosXformularioRepository.GetEntitiesByCodFormulario((int)FormularioPrincipalEnum.Solicitud_Conexion_Servicio);
            var ListadoComercializador = await _unitOfWork.ComercializadorRepository.GetEntities();

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
