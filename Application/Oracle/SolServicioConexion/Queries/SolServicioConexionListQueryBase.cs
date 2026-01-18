namespace Application.Oracle.SolServicioConexion.Queries
{
    //using Application.Oracle.PasosSolServicioConexion.DTOs;
    //using Application.Oracle.SolReciboTecnico.DTOs;
    using Application.Oracle.SolServicioConexion.DTOs;
    //using Application.Oracle.SolServicioConexionAnexo.DTOs;
    //using Application.Oracle.SolServicioConexionComentarioAnexos.DTOs;
    //using Application.Oracle.SolServicioConexionDisenio.DTOs;
    //using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    //using Application.Oracle.SolServicioConexionReciboTecnico.DTOs;
    //using Application.Oracle.SolServicioConexionSeguimientoObra.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;
    using Core.Entities.SQLContext;
    using Core.Enumerations;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using System.Linq;

    public class SolServicioConexionListQueryBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SolServicioConexionListQueryBase(IMapper mapper, IUnitOfWork unitOfWork)
       {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        internal async Task<List<SolServicioConexionDTO>> GetDtoListAsync(List<SolServicioConexionDTO> entities, bool includeAllDependencies = false)
        {
            var resultList = _mapper.Map<List<SolServicioConexionDTO>>(entities);

            var estados = await _unitOfWork.EstadoRepository.GetEntities();

            //PasosPorEtapaSolServicioconexion(resultList, includeAllDependencies);
            //await GetAlertsAsync(resultList);
            //await GetSolicitudOtherAnexos(resultList, estados);
            //await GetFactibilidadAsync(resultList);
            //await GetFactibilidadAsync(resultList, estados, includeAllDependencies);
            //await GetDisenioAsync(resultList, estados, includeAllDependencies);
            //await GetSeguimientoObraAsync(resultList, includeAllDependencies, estados);
            //await GetReciboTecnicoAnexosAsync(resultList, estados, includeAllDependencies);
            //await GetComentariosAsync(resultList, includeAllDependencies);
            //await GetDesistimientoAsync(resultList, includeAllDependencies);
            //await GetAnulacionAsync(resultList, includeAllDependencies);

            return resultList;
        }

        //private async Task GetSolicitudOtherAnexos(List<Creg075ServicioConexion> entitiesDto, List<CregEstado> estados)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var status = new int[] {
        //        (int)EstadosEnum.Creg_075_Recepcion_solicitud,
        //        (int)EstadosEnum.Creg_075_Pendiente_documentacion
        //    };

        //    var reviews = await GetOtherAnexos(entitiesIds, status);

        //    foreach (var entity in entitiesDto)
        //    {
        //        var reviewsBysolicitud = reviews.Where(x => x.CodSolServicioConexion == entity.Id).ToList();

        //        var anexos = entity.Creg075Anexos.ToList();

        //        foreach (var review in reviewsBysolicitud)
        //        {
        //            foreach (var item in review.SolServicioConexionReviewoAnexos)
        //            {
        //                var anexo = _mapper.Map<SolServicioConexionAnexoDTO>(item);
        //                var estado = estados.First(x => x.Id == review.CodEstado);
        //                anexo.Source = estado.ParDescripcion;
        //                anexos.Add(anexo);
        //            }
        //        }

        //        entity.Creg075Anexos = [.. anexos
        //            .OrderByDescending(x => x.FechaRegistro)
        //            .ThenByDescending(x => x.Id)
        //        ];
        //    }
        //}

        //public static void PasosPorEtapaSolServicioconexion(List<SolServicioConexionDTO> entitiesDto, bool includeAllDependencies)
        //{
        //    if (includeAllDependencies)
        //    {
        //        foreach (var solicitud in entitiesDto)
        //        {
        //            solicitud.PasosPorEtapaSolServicioConexion = [.. solicitud.PasosSolServicioConexions
        //               .GroupBy(paso => paso.Etapa)
        //               .Select(grupo => new PasosPorEtapaSolServicioConexionDTO
        //               {
        //                   Etapa = grupo.Key,
        //                   PasosSolServicioConexion = [.. grupo]
        //               })
        //            ];
        //        }
        //    }
        //}

        //private async Task GetSeguimientoObraAsync(List<SolServicioConexionDTO> entitiesDto, bool includeAllDependencies, List<Estado> estados)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var status = new int[] {
        //        (int)EstadosEnum.Creg_075_Diseño_conforme,
        //        (int)EstadosEnum.Creg_075_Solicitud_de_seguimiento_a_la_obra,
        //        (int)EstadosEnum.Creg_075_Seguimiento_a_la_obra_conforme,
        //        (int)EstadosEnum.Creg_075_Pendiente_documentacion_seguimiento_a_la_obra,
        //        (int)EstadosEnum.Creg_075_Seguimiento_a_la_obra_no_conforme
        //    };

        //    var OtherAnexosStatus = new int[] {
        //        (int)EstadosEnum.Creg_075_Solicitud_de_seguimiento_a_la_obra
        //    };

        //    var reviews = await GetOtherAnexos(entitiesIds, status);

        //    var reviewsIds = reviews.Select(x => x.Id).ToList();

        //    List<SolServicioConexionReviewAnexos> anexos = [];

        //    if (includeAllDependencies)
        //        anexos = await _unitOfWork.SolServicioConexionReviewAnexosRepository.GetAllAsync(
        //            filter: x => reviewsIds.Contains(x.CodSolServicioConexionReview)
        //        );

        //    if (reviews.Count != 0)
        //    {
        //        foreach (var entitie in entitiesDto)
        //        {
        //            var reviewsBySolicitud = reviews.Where(x => x.CodSolServicioConexion == entitie.Id).ToList();

        //            entitie.SeguimientosObra = [];

        //            if (includeAllDependencies)
        //            {
        //                foreach (var review in reviewsBySolicitud)
        //                {
        //                    List<SeguimientoObraAnexoDTO> anexosDto = [];

        //                    var anexosByReview = anexos
        //                        .Where(x => x.CodSolServicioConexionReview == review.Id && x.Estado.HasValue && x.Estado.Value)
        //                        .OrderBy(x => x.FechaRegistroUpdate)
        //                        .ToList();

        //                    if (anexosByReview.Count != 0)
        //                    {
        //                        var actualAnexosDto = _mapper.Map<List<SeguimientoObraAnexoDTO>>(anexosByReview);
        //                        anexosDto = actualAnexosDto;
        //                    }

        //                    if (!entitie.SeguimientosObra.Any(x => x.Etapa == review.Etapa))
        //                    {
        //                        var seguimiento = new SeguimientoObraDTO()
        //                        {
        //                            CodServicioConexion = entitie.Id,
        //                            Etapa = review.Etapa,
        //                            SeguimientoObraAnexos = []
        //                        };

        //                        entitie.SeguimientosObra.Add(seguimiento);
        //                        MarkLikeOtherAnexo(OtherAnexosStatus, review, anexosDto, seguimiento, estados);
        //                    }
        //                    else
        //                    {
        //                        var seguimiento = entitie.SeguimientosObra.First(x => x.Etapa == review.Etapa);
        //                        MarkLikeOtherAnexo(OtherAnexosStatus, review, anexosDto, seguimiento, estados);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private static void MarkLikeOtherAnexo(int[] OtherAnexosStatus, SolServicioConexionReview? review, List<SeguimientoObraAnexoDTO> anexosDto, SeguimientoObraDTO seguimiento, List<Estado> estados)
        //{
        //    foreach (var anexo in anexosDto)
        //    {
        //        if (OtherAnexosStatus.Contains(review.CodEstado))
        //            anexo.Source = estados.First(x => x.Id == review.CodEstado).ParDescripcion;

        //        seguimiento.SeguimientoObraAnexos.Add(anexo);
        //    }
        //}

        //private async Task<List<SolServicioConexionReview>> GetOtherAnexos(List<int> entitiesIds, int[] status)
        //{
        //    var excludeProcedure = new string[] { "Desistir", "DesistimientoReview", "AnulacionReview" };

        //    var reviews = await _unitOfWork.SolServicioConexionReviewRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        && status.Contains(x.CodEstado)
        //        && x.Estado.HasValue
        //        && x.Estado.Value
        //        && !excludeProcedure.Contains(x.ProcedimientoOrigen),
        //        includeObjectProperties: x => x.SolServicioConexionReviewoAnexos,
        //        orderBy: q => q.OrderBy(review => review.Etapa)
        //    );

        //    return reviews;
        //}

        //private async Task GetDesistimientoAsync(List<SolServicioConexionDTO> entitiesDto, bool includeAllDependencies)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var includeProcedure = new string[] { "Desistir", "DesistimientoReview" };

        //    var reviews = await _unitOfWork.SolServicioConexionReviewRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        && x.Estado.HasValue
        //        && x.Estado.Value
        //        && includeProcedure.Contains(x.ProcedimientoOrigen),
        //        orderBy: q => q.OrderBy(review => review.Etapa)
        //    );

        //    var reviewsIds = reviews.Select(x => x.Id).ToList();

        //    List<SolServicioConexionReviewAnexos> anexos = [];

        //    if (includeAllDependencies)
        //        anexos = await _unitOfWork.SolServicioConexionReviewAnexosRepository.GetAllAsync(
        //            filter: x => reviewsIds.Contains(x.CodSolServicioConexionReview)
        //        );

        //    if (reviews.Count != 0)
        //    {
        //        foreach (var entitie in entitiesDto)
        //        {
        //            var reviewsBySolicitud = reviews.Where(x => x.CodSolServicioConexion == entitie.Id).ToList();

        //            entitie.Desistimientos = [];

        //            if (includeAllDependencies)
        //            {
        //                foreach (var review in reviewsBySolicitud)
        //                {
        //                    List<DesistimientoAnexoDTO> anexosDto = [];

        //                    var anexosByReview = anexos
        //                        .Where(x => x.CodSolServicioConexionReview == review.Id && x.Estado.HasValue && x.Estado.Value)
        //                        .OrderBy(x => x.FechaRegistroUpdate)
        //                        .ToList();

        //                    if (anexosByReview.Count != 0)
        //                    {
        //                        var actualAnexosDto = _mapper.Map<List<DesistimientoAnexoDTO>>(anexosByReview);
        //                        anexosDto = actualAnexosDto;
        //                    }

        //                    if (entitie.Desistimientos.Count == 0)
        //                    {
        //                        entitie.Desistimientos.Add(
        //                            new DesistimientoDTO()
        //                            {
        //                                CodServicioConexion = entitie.Id,
        //                                DesistimientoAnexos = anexosDto
        //                            }
        //                        );
        //                    }
        //                    else
        //                    {
        //                        var desistimiento = entitie.Desistimientos.First();
        //                        desistimiento.DesistimientoAnexos.AddRange(anexosDto);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private async Task GetAlertsAsync(List<SolServicioConexionDTO> entities)
        //{
        //    var entitiesIds = entities.Select(e => e.Id).ToList();

        //    var alertasSolServcioConexion = await _unitOfWork.AlertaSolServicioConexionRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodServicioConexion)
        //    );

        //    foreach (var entitie in entities)
        //    {
        //        var alert = alertasSolServcioConexion.FirstOrDefault(
        //            x => x.CodServicioConexion == entitie.Id 
        //            && x.Estado.HasValue && x.Estado.Value
        //        );

        //        entitie.Alert = alert != null ? new AlertSolServicioConexionDTO() { 
        //            IdAlertaSolServicioConexion = alert.Id, 
        //            Mensaje = alert.MensajePersonalizado 
        //        } : new AlertSolServicioConexionDTO();
        //    }
        //}

        //private async Task GetFactibilidadAsync(List<Creg075ServicioConexion> entitiesDto)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var temps = await _unitOfWork.SolServicioConexionFactibilidadRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        && x.Estado.HasValue
        //        && x.Estado.Value
        //    );

        //    if (temps.Count != 0)
        //    {
        //        foreach (var entitie in entitiesDto)
        //        {
        //            var tempsEntitie = temps.Where(x => x.CodSolServicioConexion == entitie.Id).ToList();
        //            entitie.HasFactibilidadTemp = tempsEntitie.Count != 0;//&& tempsEntitie.Count == 1;
        //        }
        //    }
        //}

        //private async Task GetFactibilidadAsync(List<SolServicioConexionDTO> entitiesDto, List<Estado> estados, bool includeAllDependencies = false)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var factibilidades = await _unitOfWork.SolServicioConexionFactibilidadRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        && x.Estado.HasValue
        //        && x.Estado.Value
        //    );

        //    var factibilidadesIdsEntities = factibilidades.Select(e => e.Id).ToList();

        //    List<SolServicioConexionFactibilidadAnexos> anexos = [];
        //    List<SolServicioConexionReview> otherAnexosReviews = [];

        //    if (includeAllDependencies)
        //    {
        //        anexos = await _unitOfWork.SolServicioConexionFactibilidadAnexoRepository.GetAllAsync(
        //            filter: x => factibilidadesIdsEntities.Contains(x.CodSolServicioConexionFactibilidad)
        //        );

        //        var status = new int[] {
        //            (int)EstadosEnum.Creg_075_Estudio_factibilidad,
        //            (int)EstadosEnum.Creg_075_Factibilidad_servicio_otorgada
        //        };

        //        otherAnexosReviews = await GetOtherAnexos(entitiesIds, status);
        //    }

        //    if (factibilidades.Count != 0)
        //    {
        //        foreach (var entitie in entitiesDto)
        //        {
        //            var factibilidad = factibilidades.FirstOrDefault(x => x.CodSolServicioConexion == entitie.Id);

        //            if (factibilidad != null)
        //            {
        //                List<FactibilidadAnexosDTO> anexosDto = [];

        //                if (includeAllDependencies)
        //                {
        //                    var factibilidadAnexos = anexos
        //                        .Where(x => x.CodSolServicioConexionFactibilidad == factibilidad.Id && x.Estado.HasValue && x.Estado.Value)
        //                        .OrderBy(x => x.FechaRegistroUpdate)
        //                        .ToList();

        //                    var otherAnexosBySolicitud = otherAnexosReviews.Where(
        //                        x => x.CodSolServicioConexion == factibilidad.CodSolServicioConexion
        //                    ).ToList();

        //                    anexosDto = _mapper.Map<List<FactibilidadAnexosDTO>>(factibilidadAnexos);

        //                    foreach (var otherAnexo in otherAnexosBySolicitud)
        //                    {
        //                        foreach (var item in otherAnexo.SolServicioConexionReviewoAnexos)
        //                        {
        //                            var anexo = _mapper.Map<FactibilidadAnexosDTO>(item);

        //                            var estado = estados.First(x => x.Id == otherAnexo.CodEstado);

        //                            anexo.Source = estado.ParDescripcion;
        //                            anexosDto.Add(anexo);
        //                        }
        //                    }
        //                }

        //                entitie.Factibilidad = new FactibilidadConAnexosDTO()
        //                {
        //                    Id = factibilidad.Id,
        //                    CodSolServicioConexion = factibilidad.CodSolServicioConexion,
        //                    CodSolServicioConexionFactibilidad = factibilidad.Id,
        //                    NumeroFactibilidad = factibilidad.NumeroFactibilidad,
        //                    FactibilidadAnexos = [.. anexosDto.OrderBy(x => x.FechaRegistro)]
        //                };
        //            }
        //        }
        //    }
        //}

        //private async Task GetDisenioAsync(List<SolServicioConexionDTO> entitiesDto, List<Estado> estados, bool includeAllDependencies = false)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var disenios = await _unitOfWork.SolServicioConexionDisenioRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodServicioConexion)
        //        && x.Estado.HasValue
        //        && x.Estado.Value
        //    );

        //    List<SolServicioConexionDisenioAnexo> anexos = [];
        //    List<SolServicioConexionReview> otherAnexosReviews = [];

        //    if (includeAllDependencies)
        //    {
        //        anexos = await _unitOfWork.SolServicioConexionDisenioAnexoRepository.GetAllAsync(
        //            filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        );

        //        var status = new int[] {
        //            (int)EstadosEnum.Creg_075_Revision_diseños,
        //            (int)EstadosEnum.Creg_075_Pendiente_documentacion_diseños,
        //            (int)EstadosEnum.Creg_075_Diseño_no_conforme
        //        };

        //        otherAnexosReviews = await GetOtherAnexos(entitiesIds, status);
        //    }

        //    if (disenios.Count != 0)
        //    {
        //        foreach (var entitie in entitiesDto)
        //        {
        //            var disenio = disenios.FirstOrDefault(
        //                x => x.CodServicioConexion == entitie.Id 
        //                && x.Estado.HasValue 
        //                && x.Estado.Value 
        //                && x.Etapa == entitie.Etapa
        //            );

        //            if (disenio != null)
        //            {
        //                List<DisenioAnexosDTO> anexosDto = [];

        //                if (includeAllDependencies)
        //                {
        //                    var disenioAnexos = anexos
        //                        .Where(x => x.CodServicioConexionDisenio == disenio.Id && x.Estado.HasValue && x.Estado.Value)
        //                        .OrderBy(x => x.FechaRegistroUpdate)
        //                        .ToList();

        //                    anexosDto = _mapper.Map<List<DisenioAnexosDTO>>(disenioAnexos);

        //                    var otherAnexosBySolicitud = otherAnexosReviews
        //                        .Where(x => x.CodSolServicioConexion == disenio.CodServicioConexion)
        //                        .ToList();

        //                    foreach (var otherAnexo in otherAnexosBySolicitud)
        //                    {
        //                        foreach (var item in otherAnexo.SolServicioConexionReviewoAnexos)
        //                        {
        //                            var anexo = _mapper.Map<DisenioAnexosDTO>(item);

        //                            var estado = estados.First(x => x.Id == otherAnexo.CodEstado);

        //                            anexo.Source = estado.ParDescripcion;
        //                            anexosDto.Add(anexo);
        //                        }
        //                    }
        //                }

        //                entitie.Disenio = new DisenioConAnexosDTO()
        //                {
        //                    CodServicioConexion = disenio.CodServicioConexion,
        //                    TipoDocumento = disenio.TipoDocumento,
        //                    NombreProyecto = disenio.NombreProyecto,
        //                    NombreConstructora = disenio.NombreConstructora,
        //                    Nit = disenio.Nit,
        //                    TieneDocumentacion = disenio.TieneDocumentacion,
        //                    SolServicioConexionDisenioAnexo = [.. anexosDto.OrderBy(x => x.FechaRegistro)],
        //                    Etapa = disenio.Etapa,
        //                    NombreObservaciones = disenio.NombreObservaciones,
        //                    CedulaObservaciones = disenio.CedulaObservaciones                           
        //                };
        //            }
        //        }
        //    }
        //}

        //private async Task GetReciboTecnicoAnexosAsync(List<SolServicioConexionDTO> entitiesDto, List<Estado> estados, bool includeAllDependencies = false)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var resibosTecnicos = await _unitOfWork.SolServicioConexionReciboTecnicoRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        && x.Estado.HasValue
        //        && x.Estado.Value,
        //        orderBy: q => q.OrderBy(recibo => recibo.Etapa)
        //    );

        //    List<SolServicioConexionReciboTecnicoAnexos> anexos = [];
        //    List<SolServicioConexionReview> otherAnexosReviews = [];

        //    if (includeAllDependencies)
        //    {
        //        anexos = await _unitOfWork.SolServicioConexionReciboTecnicoAnexosRepository.GetAllAsync(
        //            filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        );
                
        //        var status = new int[] {
        //            (int)EstadosEnum.Creg_075_Solicitud_recibo_tecnico,
        //            (int)EstadosEnum.Creg_075_Pendiente_documentacion_recibo_tecnico,
        //            (int)EstadosEnum.Creg_075_Recibo_tecnico_rechazado,
        //            (int)EstadosEnum.Creg_075_Recibo_tecnico_aprobado,
        //            (int)EstadosEnum.Creg_075_Recibo_tecnico_aprobado_de_la_etapa
        //        };

        //        otherAnexosReviews = await GetOtherAnexos(entitiesIds, status);
        //    }

        //    if (resibosTecnicos.Count != 0)
        //    {
        //        foreach (var entitie in entitiesDto)
        //        {
        //            entitie.ReciboTecnico = [];

        //            foreach (var recibo in resibosTecnicos)
        //            {
        //                if (recibo != null)
        //                {
        //                    List<ReciboTecnicoAnexoDTO> anexosDto = [];

        //                    if (includeAllDependencies)
        //                    {
        //                        var reciboAnexos = anexos
        //                            .Where(x => x.CodSolServicioConexionReciboTecnico == recibo.Id && x.Estado.HasValue && x.Estado.Value)
        //                            .OrderBy(x => x.FechaRegistroUpdate)
        //                            .ToList();

        //                        anexosDto = _mapper.Map<List<ReciboTecnicoAnexoDTO>>(reciboAnexos);

        //                        var otherAnexosBySolicitud = otherAnexosReviews
        //                            .Where(x => x.CodSolServicioConexion == recibo.CodSolServicioConexion && x.Etapa == recibo.Etapa)
        //                            .ToList();

        //                        foreach (var otherAnexo in otherAnexosBySolicitud)
        //                        {
        //                            foreach (var item in otherAnexo.SolServicioConexionReviewoAnexos)
        //                            {
        //                                var anexo = _mapper.Map<ReciboTecnicoAnexoDTO>(item);

        //                                var estado = estados.First(x => x.Id == otherAnexo.CodEstado);

        //                                anexo.Source = estado.ParDescripcion;
        //                                anexosDto.Add(anexo);
        //                            }
        //                        }
        //                    }

        //                    entitie.ReciboTecnico.Add(new ReciboTecnicoDTO()
        //                    {
        //                        Id = entitie.Id,
        //                        Etapa = recibo.Etapa,
        //                        ReciboTecnicoInfo = _mapper.Map<ReciboTecnicoBaseDTO>(recibo),
        //                        ReciboTecnicoAnexos = [.. anexosDto.OrderBy(x => x.FechaRegistro)]
        //                    });
        //                }
        //            }
        //        }
        //    }
        //}

        //private async Task GetComentariosAsync(List<SolServicioConexionDTO> entitiesDto, bool includeAllDependencies = false)
        //{
        //    if (includeAllDependencies)
        //    {
        //        foreach (var solicitudDto in entitiesDto)
        //        {
        //            foreach (var comentario in solicitudDto.SolServicioConexionComentarios)
        //            {
        //                if (comentario == null || comentario.SolServicioConexionComentarioAnexos.Count == 0)
        //                {
        //                    var anexos = await _unitOfWork.SolServicioConexionComentarioAnexoRepository.GetEntitiesByCodComentario(comentario.Id);

        //                    if (anexos == null || anexos.Count != 0)
        //                    {
        //                        continue;
        //                    }

        //                    comentario.SolServicioConexionComentarioAnexos = _mapper.Map<List<SolServicioConexionComentarioAnexosDTO>>(anexos);
        //                }
        //            }
        //        }
        //    }
        //}

        //private async Task GetAnulacionAsync(List<SolServicioConexionDTO> entitiesDto, bool includeAllDependencies)
        //{
        //    var entitiesIds = entitiesDto.Select(e => e.Id).ToList();

        //    var includeProcedure = new string[] { "AnulacionReview" };

        //    var reviews = await _unitOfWork.SolServicioConexionReviewRepository.GetAllAsync(
        //        filter: x => entitiesIds.Contains(x.CodSolServicioConexion)
        //        && x.Estado.HasValue
        //        && x.Estado.Value
        //        && includeProcedure.Contains(x.ProcedimientoOrigen),
        //        orderBy: q => q.OrderBy(review => review.Etapa)
        //    );

        //    var reviewsIds = reviews.Select(x => x.Id).ToList();

        //    List<SolServicioConexionReviewAnexos> anexos = [];

        //    if (includeAllDependencies)
        //        anexos = await _unitOfWork.SolServicioConexionReviewAnexosRepository.GetAllAsync(
        //            filter: x => reviewsIds.Contains(x.CodSolServicioConexionReview)
        //        );

        //    if (reviews.Count != 0)
        //    {
        //        foreach (var entitie in entitiesDto)
        //        {
        //            var reviewsBySolicitud = reviews.Where(x => x.CodSolServicioConexion == entitie.Id).ToList();

        //            entitie.Anulaciones = [];

        //            if (includeAllDependencies)
        //            {
        //                foreach (var review in reviewsBySolicitud)
        //                {
        //                    List<AnulacionAnexoDTO> anexosDto = [];

        //                    var anexosByReview = anexos
        //                                        .Where(x => x.CodSolServicioConexionReview == review.Id && x.Estado.HasValue && x.Estado.Value)
        //                                        .OrderBy(x => x.FechaRegistroUpdate)
        //                                        .ToList();

        //                    if (anexosByReview.Count != 0)
        //                    {
        //                        var actualAnexosDto = _mapper.Map<List<AnulacionAnexoDTO>>(anexosByReview);
        //                        anexosDto = actualAnexosDto;
        //                    }

        //                    if (entitie.Anulaciones.Count == 0)
        //                    {
        //                        entitie.Anulaciones.Add(
        //                            new AnulacionDTO()
        //                            {
        //                                CodServicioConexion = entitie.Id,
        //                                AnulacionAnexos = anexosDto
        //                            }
        //                        );
        //                    }
        //                    else
        //                    {
        //                        var anulacion = entitie.Anulaciones.First();
        //                        anulacion.AnulacionAnexos.AddRange(anexosDto);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
