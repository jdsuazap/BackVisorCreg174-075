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


            //solicitud.PasosSolConexionAutogens = await GetPasosBySolicitud(idEntity);

            //solicitud.SolConexionAutogenXvisita = await GetVisitaBySolicitud(idEntity);

            //solicitud.SolConexionAutogenComentarios = await GetComentarioBySolicitud(idEntity);

            //solicitud.SolConexionAutogenObservacions = await GetObservacionBySolicitud(idEntity);

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
        //public async Task<List<SolConexionAutogenContratoAnexo>> GetContratoConexionAnexosBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetContratoConexionAnexosBySolicitud(idEntity);
        //}
        //public async Task<List<SolConexionAutogenDocumentacionRetieRechazo>> GetDocumentacionRetieRechazoBySolicitud(int idEntity)
        //{
        //    var lstDocumentacionRetieRechazo = new List<SolConexionAutogenDocumentacionRetieRechazo>();

        //    var lstQuery = await _unitOfWork.SolConexionAutogenRepository.GetDocumentacionRetieRechazoBySolicitud(idEntity);

        //    foreach (var item in lstQuery)
        //    {
        //        if (lstDocumentacionRetieRechazo.Count == 0)
        //        {
        //            lstDocumentacionRetieRechazo.Add(item);
        //        }
        //        else
        //        {
        //            if (item.SolConexionAutogenDocumentacionRetieRechazoAnexos != null && item.SolConexionAutogenDocumentacionRetieRechazoAnexos.Count > 0)
        //            {
        //                lstDocumentacionRetieRechazo[0].SolConexionAutogenDocumentacionRetieRechazoAnexos.Add(item.SolConexionAutogenDocumentacionRetieRechazoAnexos.ToList()[0]);
        //            }
        //        }
        //    }

        //    return lstDocumentacionRetieRechazo;
        //}
        //public async Task<List<SolConexionAutogenAnexoRechazo>> GetAnexoRechazosBySolicitud(int idEntity)
        //{
        //    //Obtener los datos
        //    var resp = await _unitOfWork.SolConexionAutogenRepository.GetAnexoRechazosBySolicitud(idEntity);

        //    //Si no hay datos
        //    if (resp.Count == 0)
        //    {
        //        //Se envia datos vacios
        //        return [];
        //    }

        //    //Inicio para la organización de los datos
        //    var lstAnexoRechazo = new List<SolConexionAutogenAnexoRechazo>();

        //    // Inicia ciclo
        //    foreach (var anexoRechazo in resp)
        //    {
        //        //Se valida si existe rechazos en la lista 
        //        var anexoRechazoIndex = lstAnexoRechazo.FindIndex(ar => ar.Id == anexoRechazo.Id);

        //        //Si no existe en la lista
        //        if (anexoRechazoIndex == -1)
        //        {
        //            //Se agrega el rechazo a lista
        //            lstAnexoRechazo.Add(anexoRechazo);

        //            //Se ajusta el indice en donde se encuentra el rechazo en la lista
        //            anexoRechazoIndex = lstAnexoRechazo.Count - 1;
        //        }

        //        //Obteniendo los anexos 
        //        var anexoRechazoAnexo = anexoRechazo.SolConexionAutogenAnexoRechazoAnexos.FirstOrDefault();

        //        //Si existen anexos
        //        if (anexoRechazoAnexo != null)
        //        {
        //            //Obteniendo el indice donde puede estar el anexo 
        //            var valAnexo = lstAnexoRechazo[anexoRechazoIndex].SolConexionAutogenAnexoRechazoAnexos.FirstOrDefault(a => a.Id == anexoRechazoAnexo.Id);

        //            //Si no existe el anexo
        //            if (valAnexo == null)
        //            {
        //                //Se agrega el anexo a la lista
        //                lstAnexoRechazo[anexoRechazoIndex].SolConexionAutogenAnexoRechazoAnexos.Add(anexoRechazoAnexo);
        //            }
        //        }
        //    }

        //    return lstAnexoRechazo;
        //}        

        //public async Task<List<SolConexionAutogenViabilidadTecnicaRechazo>> GetViabilidadTecnicaRechazos(int idEntity)
        //{
        //    //Obtener los datos
        //    var resp = await _unitOfWork.SolConexionAutogenRepository.GetViabilidadTecnicaRechazos(idEntity);

        //    //Si no hay datos
        //    if (resp.Count == 0)
        //    {
        //        //Se envia datos vacios
        //        return new();
        //    }

        //    //Inicio para la organización de los datos
        //    var lstViabilidadTecnicaRechazo = new List<SolConexionAutogenViabilidadTecnicaRechazo>();

        //    // Inicia ciclo
        //    foreach (var rechazo in resp)
        //    {
        //        //Se valida si existe rechazos en la lista 
        //        var rechazoIndex = lstViabilidadTecnicaRechazo.FindIndex(r => r.Id == rechazo.Id);

        //        //Si no existe en la lista
        //        if (rechazoIndex == -1)
        //        {
        //            //Se agrega el rechazo a lista
        //            lstViabilidadTecnicaRechazo.Add(rechazo);

        //            //Se ajusta el indice en donde se encuentra el rechazo en la lista
        //            rechazoIndex = lstViabilidadTecnicaRechazo.Count - 1;
        //        }

        //        //Obteniendo los anexos 
        //        var rechazoAnexo = rechazo.SolConexionAutogenViabilidadTecnicaRechazoAnexos.FirstOrDefault();

        //        //Si existen anexos
        //        if (rechazoAnexo != null)
        //        {
        //            //Obteniendo el indice donde puede estar el anexo 
        //            var valAnexo = lstViabilidadTecnicaRechazo[rechazoIndex].SolConexionAutogenViabilidadTecnicaRechazoAnexos.FirstOrDefault(a => a.Id == rechazoAnexo.Id);

        //            //Si no existe el anexo
        //            if (valAnexo == null)
        //            {
        //                //Se agrega el anexo a la lista
        //                lstViabilidadTecnicaRechazo[rechazoIndex].SolConexionAutogenViabilidadTecnicaRechazoAnexos.Add(rechazoAnexo);
        //            }
        //        }
        //    }

        //    return lstViabilidadTecnicaRechazo;
        //}
        //public async Task<List<PasosSolConexionAutogen>> GetPasosBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetPasosBySolicitud(idEntity);
        //}
        //public async Task<List<SolConexionAutogenXprorroga>> GetProrrogaBySolicitud(int idEntity)
        //{
        //    var lstProrroga = await _unitOfWork.SolConexionAutogenRepository.GetProrrogaBySolicitud(idEntity);

        //    for (int i = 0; i < lstProrroga.Count; i++)
        //    {
        //        lstProrroga[i].SolConexionAutogenXprorrogaGarantia = await _unitOfWork.SolConexionAutogenXprorrogaRepository.GetProrrogaGarantiaById(lstProrroga[i].Id);
        //    }

        //    return lstProrroga;
        //}
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
        //public async Task<List<SolConexionAutogenConexionRechazo>> GetConexionRechazosBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetConexionRechazosBySolicitud(idEntity);
        //}
        //public async Task<List<SolConexionAutogenReporteHallazgo>> GetReporteHallazgosBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetReporteHallazgosBySolicitud(idEntity);
        //}
        //public async Task<List<SolConexionAutogenDesistimiento>> GetDesistimientosBySolicitud(int idEntity)
        //{
        //    return await _unitOfWork.SolConexionAutogenRepository.GetDesistimientosBySolicitud(idEntity);
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
