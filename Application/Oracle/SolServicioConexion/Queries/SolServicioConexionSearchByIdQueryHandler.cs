namespace Application.Oracle.SolServicioConexion.Queries
{
    using Application.Oracle.SolServicioConexion.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class SolServicioConexionSearchByIdQueryHandler : SolServicioConexionListQueryBase, IRequestHandler<SolServicioConexionSearchByIdQuery, SolServicioConexionDTO>
    {
        private readonly ISolServicioConexionService _solServicioConexionService;
        private readonly IMapper _mapper;

        public SolServicioConexionSearchByIdQueryHandler(ISolServicioConexionService solServicioConexionService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            : base(mapper,
                  unitOfWork)
        {
            _mapper = mapper;
            _solServicioConexionService = solServicioConexionService;
        }

        public async Task<SolServicioConexionDTO> Handle(SolServicioConexionSearchByIdQuery request, CancellationToken cancellationToken)
        {
            var solServicio = new SolServicioConexionDTO
            {
                Id = request.Id,
                Empresa = request.Empresa
            };

            var entity = await _solServicioConexionService.GetEntity(solServicio.Id, solServicio.Empresa);

            //var entities = await GetDtoListAsync(entity, true);
            var result = _mapper.Map<SolServicioConexionDTO>(entity);

            return result;
        }
    }
}
