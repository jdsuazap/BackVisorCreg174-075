namespace Application.SQLContext.SolReciboTecnico.Queries
{
    using Application.Oracle.SolReciboTecnico.DTOs;
    using Application.Oracle.SolReciboTecnico.Queries;
    using Application.Oracle.SolServicioConexionReciboTecnico.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;
    using Core.Exceptions;
    using Core.Interfaces;
    using MediatR;
    using System.Linq.Expressions;

    public class SolServicioConexionReciboTecnicoSearchByIdQueryHandler : IRequestHandler<SolServicioConexionReciboTecnicoSearchByIdQuery, List<SolServicioConexionReciboTecnicoPorEtapasDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SolServicioConexionReciboTecnicoSearchByIdQueryHandler(
            IUnitOfWork solReciboTecnicoService,
            IMapper mapper)
        {
            _unitOfWork = solReciboTecnicoService;
            _mapper = mapper;
        }

        public async Task<List<SolServicioConexionReciboTecnicoPorEtapasDTO>> Handle(SolServicioConexionReciboTecnicoSearchByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Creg075ReciboTecnico, object>>[] includes = {
                    x => x.Creg075ReciboTecnicoAnexo,
                    x => x.Creg075ServicioConexion,
                    x => x.Creg075ReciboTecnicoProy
            };

            var solicitud = (await _unitOfWork.SolServicioConexionRepository.GetAll(filter: x => x.NumeroRadicado == request.Numero_Radicado)).FirstOrDefault();
            if (solicitud == null)
                throw new BusinessException("Error no existe la solicitud");

            var entities = (await _unitOfWork.SolServicioConexionReciboTecnicoRepository.GetAll(filter: x => x.Cod075Conexion == request.Id
            && x.Estado.HasValue
            && x.Estado.Value, includeObjectProperties: includes)).ToList();

            if (entities == null || !entities.Any())
                return null;
            
            List<SolServicioConexionReciboTecnicoPorEtapasDTO> solServicioConexionReciboTecnicoPorEtapas = new List<SolServicioConexionReciboTecnicoPorEtapasDTO>();

            foreach (var entity in entities)
            {
                var entity_solicitud = await _unitOfWork.SolServicioConexionRepository.GetEntity(Convert.ToInt32(entity.Creg075ServicioConexion.NumeroRadicado), request.Empresa);

                var reciboTecnicoDto = _mapper.Map<SolServicioConexionReciboTecnicoDTO>(entity);

                reciboTecnicoDto.NumeroFactibilidad = entity_solicitud.Creg075Factibilidads.FirstOrDefault().NumeroFactibilidad;
                reciboTecnicoDto.NumeroMatricula = entity_solicitud.Creg075Predios.MatriculaInmobiliaria;
                reciboTecnicoDto.CodTiposProyectos = entity.Creg075ReciboTecnicoProy.Select(x => x.CodTipoProyecto).ToList();

                var reciboPorEtapa = solServicioConexionReciboTecnicoPorEtapas.FirstOrDefault(x => x.Etapa == entity.Etapa);
                if (reciboPorEtapa != null)
                {
                    reciboPorEtapa.RecibosTecnicos.Add(reciboTecnicoDto);
                }
                else
                {
                    ReciboTecnicoAnexoDTO reciboTecnicoAnexoDTO = new ReciboTecnicoAnexoDTO
                    {
                        Id = entity.Creg075ReciboTecnicoAnexo.First().Id,
                        CodDocumentosXFormulario = entity.Creg075ReciboTecnicoAnexo.First().CodDocumentos,
                        CodSolServicioConexion = entity.Creg075ReciboTecnicoAnexo.First().Cod075Conexion,
                        EstadoDocumento = entity.Creg075ReciboTecnicoAnexo.First().EstadoDocumento,
                        ExtDocument = entity.Creg075ReciboTecnicoAnexo.First().ExtDocument,
                        NameDocument = entity.Creg075ReciboTecnicoAnexo.First().NameDocument,
                        OriginalNameDocument = entity.Creg075ReciboTecnicoAnexo.First().OriginalNameDocument,
                        UrlDocument = entity.Creg075ReciboTecnicoAnexo.First().UrlDocument,
                        UrlRelDocument = entity.Creg075ReciboTecnicoAnexo.First().UrlRelDocument
                    };

                    solServicioConexionReciboTecnicoPorEtapas.Add(new SolServicioConexionReciboTecnicoPorEtapasDTO()
                    {
                        Etapa = entity.Etapa,
                        RecibosTecnicos = new List<SolServicioConexionReciboTecnicoDTO>()
                        {                                      
                           reciboTecnicoDto
                        }                        
                    });
                }
            }


            return solServicioConexionReciboTecnicoPorEtapas;
        }
    }
}
