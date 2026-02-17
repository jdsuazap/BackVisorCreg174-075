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
    using System.Linq;

    public class SolConexionAutogenService : ISolConexionAutogenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<Creg174Anexo> ListDocuments = new List<Creg174Anexo>(); // listado de archivos que se guardarán en DB
        private readonly PathOptions _pathOptions;
        private Creg174Autogen Entity = null!;

        public SolConexionAutogenService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions
        )
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
        }

        public async Task<Creg174Autogen> GetEntity(Creg174Autogen entity)
        {
            var idEntity = entity.Id;


            var solicitud = await _unitOfWork.SolConexionAutogenRepository.GetEntity(idEntity, entity.CodEmpresa)
                ?? throw new BusinessException("Solicitud inexistente");

            solicitud.Creg174TecnUtilizada = await GetTecnologiasUtilBySolicitud(idEntity);

            solicitud.Creg174Anexos = await GetAnexosBySolicitud(idEntity);

            solicitud.Creg174Historico = await GetPasosBySolicitud(idEntity);            

            return solicitud;
        }


        public async Task<List<Creg174TecnUtilizada>> GetTecnologiasUtilBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolConexionAutogenRepository.GetTecnologiasUtilBySolicitud(idEntity);
        }
        public async Task<List<Creg174Anexo>> GetAnexosBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolConexionAutogenRepository.GetAnexosBySolicitud(idEntity);
        }
               
        public async Task<List<Creg174Pasos>> GetPasosBySolicitud(int idEntity)
        {
            return await _unitOfWork.SolConexionAutogenRepository.GetPasosBySolicitud(idEntity);
        }
        
        //public async Task<List<SolConexionAutogenDocumentacionVisita>> GetDocVisitaBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetDocVisitaBySolicitud(idEntity);
        //}
        //public async Task<List<SolConexionAutogenXvisita>> GetVisitaBySolicitud(int idEntity)
        //{
        //    //Obtener los datos
        //    var resp = (await _unitOfWork.SolConexionAutogenRepository.GetVisitaBySolicitud(idEntity)).Where(x => x.Estado == 1).ToList();

        //    //Si no hay datos
        //    if (resp.Count == 0)
        //    {
        //        //Se envia datos vacios
        //        return [];
        //    }

        //    //Inicio para la organización de los datos
        //    var solConAutogenVisita = new List<SolConexionAutogenXvisita>();

        //    //Inicia ciclo
        //    foreach (var visita in resp)
        //    {
        //        //Se valida si existen datos 
        //        var visitaIndex = solConAutogenVisita.FindIndex(v => v.Id == visita.Id);

        //        //Si no existe en la lista
        //        if (visitaIndex == -1)
        //        {
        //            //Se agrega la documentación a lista
        //            solConAutogenVisita.Add(visita);

        //            //Se ajusta el indice en donde se encuentra la documentanción en la lista
        //            visitaIndex = solConAutogenVisita.Count - 1;
        //        }

        //        //Obteniendo los anexos 
        //        var visitaAnexo = visita.SolConexionAutogenXvisitaAnexos.FirstOrDefault();

        //        //Si existen anexos
        //        if (visitaAnexo != null)
        //        {
        //            //Obteniendo el indice donde puede estar el anexo 
        //            var valAnexo = solConAutogenVisita[visitaIndex].SolConexionAutogenXvisitaAnexos.FirstOrDefault(a => a.Id == visitaAnexo.Id);

        //            //Si no existe el anexo
        //            if (valAnexo == null)
        //            {
        //                //Se agrega el anexo a la lista
        //                solConAutogenVisita[visitaIndex].SolConexionAutogenXvisitaAnexos.Add(visitaAnexo);
        //            }
        //        }

        //        //Obteniendo rechazo de la documentación de la visita
        //        var docVisitaRechazo = visita.SolConexionAutogenXvisitaRechazos.FirstOrDefault();

        //        //Validación si existe rechazo
        //        if (docVisitaRechazo != null)
        //        {
        //            //Obteniendo indice en donde se puede encontrar un rechazo en la lista
        //            var indexRechazo = solConAutogenVisita[visitaIndex]
        //                                        .SolConexionAutogenXvisitaRechazos.ToList()
        //                                        .FindIndex(r => r.Id == docVisitaRechazo.Id);

        //            //Si no existe el rechazho en la lista
        //            if (indexRechazo == -1)
        //            {
        //                //Se agrega el rechazho en la lista
        //                solConAutogenVisita[visitaIndex].SolConexionAutogenXvisitaRechazos.Add(docVisitaRechazo);

        //                //Actualizando el index donde se encuentra el rechazho
        //                indexRechazo = solConAutogenVisita[visitaIndex].SolConexionAutogenXvisitaRechazos.Count - 1;
        //            }

        //            //Obteniendo anexo del rechazo
        //            var docVisitaRechazoAnexo = docVisitaRechazo.SolConexionAutogenXvisitaRechazoAnexos.FirstOrDefault();

        //            //Si existe anexo
        //            if (docVisitaRechazoAnexo != null)
        //            {
        //                //Obteniendo indice donde se puede encontrar el anexo
        //                var indexRechazoAnexo = solConAutogenVisita[visitaIndex]
        //                                                .SolConexionAutogenXvisitaRechazos.ElementAt(indexRechazo)
        //                                                .SolConexionAutogenXvisitaRechazoAnexos.ToList()
        //                                                .FindIndex(a => a.Id == docVisitaRechazoAnexo.Id);

        //                //Si no esta el anexo en la lista
        //                if (indexRechazoAnexo == -1)
        //                {
        //                    //Se agrega el anexo en la lista
        //                    solConAutogenVisita[visitaIndex]
        //                                                .SolConexionAutogenXvisitaRechazos.ElementAt(indexRechazo)
        //                                                .SolConexionAutogenXvisitaRechazoAnexos
        //                                                .Add(docVisitaRechazoAnexo);
        //                }
        //            }
        //        }
        //    }

        //    //Enviando data
        //    return solConAutogenVisita;
        //}
        //public async Task<List<SolConexionAutogenComentario>> GetComentarioBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetComentarioBySolicitud(idEntity);
        //}
        //public async Task<List<SolConexionAutogenObservacion>> GetObservacionBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetObservacionBySolicitud(idEntity);
        //}
        

        public async Task<SolConexionAutogenParamsIni> GetParametrosIniciales()
        {
            var initialParams = new SolConexionAutogenParamsIni
            {
                ListadoTipoGeneracion = await _unitOfWork.TipoGeneracionRepository.GetEntities(),
                ListadoClasificacionProyecto = await _unitOfWork.ClasificacionProyectoRepository.GetEntities(),
                ListadoComercializador = await _unitOfWork.ComercializadorRepository.GetEntities(),
                ListadoTipoIdentificacion = await _unitOfWork.TipoIdentificacionRepository.GetEntities(),
                ListadoDepartamento = await _unitOfWork.DepartamentoRepository.GetEntities(),
                ListadoCiudad = await _unitOfWork.CregCiudadRepository.GetEntities(),
                ListadoTipoCliente = await _unitOfWork.TipoClienteRepository.GetEntities(),
                ListadoTipoTecnologia = await _unitOfWork.TipoTecnologiaRepository.GetEntities(),
                ListadoTipoAerogenerador = await _unitOfWork.TipoAerogeneradorRepository.GetEntities(),
                ListadoEstratoSocioeconomico = await _unitOfWork.EstratoSocioeconomicoRepository.GetEntities(),
                ListadoTipoTramiteVisita = await _unitOfWork.TipoTramiteVisitaRepository.GetEntities(),
                ListadoDocumentosXformularios = await _unitOfWork.DocumentosXformularioRepository.GetEntitiesByCodFormulario((int)FormularioPrincipalEnum.Solicitud_Conexion_Autogenerador)
            };

            return initialParams;
        }

    }
}
