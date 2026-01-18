namespace Application.SQLContext.SolServicioConexionFactibilidad.Queries
{
    using Application.SQLContext.SolServicioConexionFactibilidad.DTOs;
    using AutoMapper;
    using Core.Interfaces.SQLContext;
    using MediatR;

    public class SolServicioConexionFactibilidadSearchByIdQueryHandler
     : IRequestHandler<
         SolServicioConexionFactibilidadSearchByIdQuery,
         SolServicioConexionFactibilidadDTO>
    {
        private readonly ISolServicioConexionFactibilidadService _solServicioConexionFactibilidadService;
        private readonly IMapper _mapper;

        public SolServicioConexionFactibilidadSearchByIdQueryHandler(
            ISolServicioConexionFactibilidadService solServicioConexionFactibilidadService,
            IMapper mapper)
        {
            _solServicioConexionFactibilidadService = solServicioConexionFactibilidadService;
            _mapper = mapper;
        }

        public async Task<SolServicioConexionFactibilidadDTO> Handle(SolServicioConexionFactibilidadSearchByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _solServicioConexionFactibilidadService.GetEntityByIdSolicitud(request.CodSolServicioConexion, request.Empresa);
            return _mapper.Map<SolServicioConexionFactibilidadDTO>(entity);
        }

        /*
        private async Task<SolServicioConexionFactibilidadDTO> GetDtoFromDatabaseAsync(Core.Entities.SQLContext.SolServicioConexionFactibilidad entity)
        {
            var observaciones = new List<SolServicioConexionFactibilidadObservaciones>();

            observaciones.AddRange(entity.SolServicioConexionFactibilidadObservaciones);

            entity.SolServicioConexionFactibilidadObservaciones = null;
            var dto = _mapper.Map<SolServicioConexionFactibilidadDTO>(entity);
            dto.SolServicioConexionFactibilidadPerfilApoyo = _mapper.Map<List<SolServicioConexionFactibilidadPerfilApoyoDTO>>(entity.SolServicioConexionFactibilidadPerfilApoyos);
            dto.SolServicioConexionFactibilidadPerfilOperativo = _mapper.Map<List<SolServicioConexionFactibilidadPerfilOperativoDTO>>(entity.SolServicioConexionFactibilidadPerfilOperativos);
            dto.SolServicioConexionFactibilidadObservaciones = new List<SolServicioConexionFactibilidadObservacionesDTO>();

            foreach (var observacion in observaciones)
            {
                dto.SolServicioConexionFactibilidadObservaciones.Add(new SolServicioConexionFactibilidadObservacionesDTO()
                {
                    GestionadoPor = observacion.GestionadoPor,
                    Id = observacion.Id,
                    NombreProyecto = observacion.NombreProyecto,
                    Observaciones = JsonConvert.DeserializeObject<List<SolServicioConexionFactibilidadObservacionDTO>>(observacion.Observaciones)
                });
            }


            foreach (var apoyo in dto.SolServicioConexionFactibilidadPerfilApoyo)
            {
                apoyo.SolServicioConexionFactibilidadDetallesCuentas = _mapper.Map<List<SolServicioConexionFactibilidadDetalleCuentasDTO>>(entity.SolServicioConexionFactibilidadDetallesCuentas);
            }

            foreach (var operativo in dto.SolServicioConexionFactibilidadPerfilOperativo)
            {
                operativo.SolServicioConexionFactibilidadDocumentosRequeridos = _mapper.Map<List<SolServicioConexionFactibilidadDocumentosRequeridosDTO>>(entity.SolServicioConexionFactibilidadPorDocumentos);
                operativo.CodTiposProyectos = entity.SolServicioConexionFactibilidadesPorProyectos.Select(x => x.CodTipoProyecto).ToList();
            }

            var anexos = await _solServicioConexionFactibilidadAnexoService.GetAllAsync(x => x.CodSolServicioConexion == entity.CodSolServicioConexion && x.CodServicioConexionFactibilidad == entity.Id);
            dto.FactibilidadAnexos = _mapper.Map<List<FactibilidadAnexosDTO>>(anexos);
            return dto;
        }

        private async Task<SolServicioConexionFactibilidadDTO> LoadFromTempInfoAsync(SolServicioConexionFactibilidadSearchByIdQuery request)
        {
            SolServicioConexionFactibilidadDTO result = new SolServicioConexionFactibilidadDTO();
            var temps = await _solServicioConexionFactibilidadTemporalService.GetAllAsync(filter:
                                                                                        x => x.CodServicioConexion == request.CodSolServicioConexion
                                                                                        && x.Estado.HasValue
                                                                                        && x.Estado.Value);

            result.CodServicioConexion = request.CodSolServicioConexion;

            SolServicioConexionFactibilidadObservacionesDTO observaciones = new SolServicioConexionFactibilidadObservacionesDTO();
            observaciones.Observaciones = new List<SolServicioConexionFactibilidadObservacionDTO>();

            foreach (var temp in temps)
            {
                GetDataFromApoyoProfile(result, observaciones, temp);

                GetDataFromOperativoProfile(result, temp, observaciones);
            }

            var anexos = await _solServicioConexionFactibilidadAnexoService.GetAllAsync(filter:
                                                                        x => x.CodSolServicioConexion == request.CodSolServicioConexion
                                                                        && x.Estado.HasValue
                                                                        && x.Estado.Value);

            result.SolServicioConexionFactibilidadObservaciones = new List<SolServicioConexionFactibilidadObservacionesDTO>();
            result.SolServicioConexionFactibilidadObservaciones.Add(observaciones);

            if (anexos.Any())
                result.FactibilidadAnexos = _mapper.Map<List<FactibilidadAnexosDTO>>(anexos);
            return result;
        }

        private static void GetDataFromOperativoProfile(SolServicioConexionFactibilidadDTO result, SolServicioConexionFactibilidadTemporal temp, SolServicioConexionFactibilidadObservacionesDTO observaciones)
        {
            if (temp.TipoPerfil == Core.Enumerations.PerfilesEnum.Operativo_CREG_075)
            {
                result.SolServicioConexionFactibilidadPerfilOperativo = new List<SolServicioConexionFactibilidadPerfilOperativoDTO>();
                var operativo = JsonConvert.DeserializeObject<SolServicioConexionFactibilidadPerfilOperativoResponseDTO>(temp.Contenido);

                var operativoDto = new SolServicioConexionFactibilidadPerfilOperativoDTO()
                {
                    FechaFactibilidad = operativo.FechaFactibilidad,
                    CodTiposProyectos = operativo.CodTiposProyectos,
                    TransformadorDistribucion = operativo.TransformadorDistribucion,
                    NumeroNodo = operativo.NumeroNodo,
                    GeoReferenciaLongitud = operativo.GeoReferenciaLongitud,
                    GeoReferenciaLatitud = operativo.GeoReferenciaLatitud,
                    GeoReferenciaH = operativo.GeoReferenciaH,
                    SolServicioConexionFactibilidadDocumentosRequeridos = operativo.SolServicioConexionFactibilidadDocumentosRequeridos
                };

                result.SolServicioConexionFactibilidadPerfilOperativo.Add(operativoDto);
                if (operativo.SolServicioConexionFactibilidadObservaciones != null)
                {
                    observaciones.NombreProyecto = operativo.SolServicioConexionFactibilidadObservaciones.NombreProyecto;
                    observaciones.GestionadoPor = operativo.SolServicioConexionFactibilidadObservaciones.GestionadoPor;

                    observaciones.Observaciones.AddRange(operativo.SolServicioConexionFactibilidadObservaciones.Observaciones);
                }
            }
        }

        private static void GetDataFromApoyoProfile(SolServicioConexionFactibilidadDTO result, SolServicioConexionFactibilidadObservacionesDTO observaciones, Core.Entities.SQLContext.SolServicioConexionFactibilidadTemporal temp)
        {
            if (temp.TipoPerfil == Core.Enumerations.PerfilesEnum.Apoyo_proyecto_CREG_075)
            {
                result.SolServicioConexionFactibilidadPerfilApoyo = new List<SolServicioConexionFactibilidadPerfilApoyoDTO>();
                var apoyo = JsonConvert.DeserializeObject<SolServicioConexionFactibilidadPerfilApoyoResponseDTO>(temp.Contenido);
                var apoyoDTO = new SolServicioConexionFactibilidadPerfilApoyoDTO()
                {
                    FechaRespuestaFactibilidad = apoyo.FechaRespuestaFactibilidad,
                    VigenciaFactibilidad = apoyo.VigenciaFactibilidad,
                    CodTipoSolicitud = apoyo.CodTipoSolicitud,
                    CargaAprobada = apoyo.CargaAprobada,
                    CargaExistente = apoyo.CargaExistente,
                    CodigoNivelAprobacion = apoyo.CodigoNivelAprobacion,
                    NombreCircuitoBT = apoyo.NombreCircuitoBT,
                    NumeroCircuitoBT = apoyo.NumeroCircuitoBT,
                    NombreCircuitoMT = apoyo.NombreCircuitoMT,
                    NumeroCircuitoMT = apoyo.NumeroCircuitoMT,
                    SubEstacionPotencia = apoyo.SubEstacionPotencia,
                    DistanciaPuntoConexion = apoyo.DistanciaPuntoConexion,
                    NivelCortocircuitoTrifasico = apoyo.NivelCortocircuitoTrifasico,
                    NivelCortocircuitoMonofasico = apoyo.NivelCortocircuitoMonofasico,
                };

                observaciones.Observaciones.AddRange(apoyo.SolServicioConexionFactibilidadObservaciones.Observaciones);

                apoyoDTO.SolServicioConexionFactibilidadDetallesCuentas = apoyo.SolServicioConexionFactibilidadDetallesCuentas;

                result.SolServicioConexionFactibilidadPerfilApoyo.Add(apoyoDTO);
            }
        }
        */
    }
}
