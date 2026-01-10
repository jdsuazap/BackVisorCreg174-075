namespace Application.SQLContext.SolReciboTecnico.Queries
{
    using Application.SQLContext.SolReciboTecnico.DTOs;
    using Application.SQLContext.SolServicioConexionReciboTecnico.DTOs;
    using AutoMapper;
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
            Expression<Func<Core.Entities.SQLContext.SolServicioConexionReciboTecnico, object>>[] includes = {
                    x=>x.CodSolServicioConexionNavigation,
            };

            var solicitud = (await _unitOfWork.SolServicioConexionRepository.GetAll(filter: x => x.Id == request.Id)).FirstOrDefault();
            if (solicitud == null)
                throw new BusinessException("Error no existe la solicitud");

            var entities = (await _unitOfWork.SolServicioConexionReciboTecnicoRepository.GetAllAsync(filter: x => x.CodSolServicioConexion == request.Id
            && x.Estado.HasValue
            && x.Estado.Value, includeObjectProperties: includes,
            orderBy: x => x.OrderBy(x => x.Etapa))).ToList();

            if (entities == null || !entities.Any())
                return null;

            List<SolServicioConexionReciboTecnicoPorEtapasDTO> solServicioConexionReciboTecnicoPorEtapas = new List<SolServicioConexionReciboTecnicoPorEtapasDTO>();

            foreach (var entity in entities)
            {
                var reciboTecnicoDto = _mapper.Map<SolServicioConexionReciboTecnicoDTO>(entity);

                reciboTecnicoDto.NumeroFactibilidad = entity.CodSolServicioConexionNavigation.NumeroRadicado;
                reciboTecnicoDto.NumeroMatricula = entity.CodSolServicioConexionNavigation.NumeroRadicado;

                var reciboPorEtapa = solServicioConexionReciboTecnicoPorEtapas.FirstOrDefault(x => x.Etapa == entity.Etapa);
                if (reciboPorEtapa != null)
                {
                    reciboPorEtapa.RecibosTecnicos.Add(reciboTecnicoDto);
                }
                else
                {
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
