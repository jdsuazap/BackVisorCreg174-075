namespace Application.SQLContext.SolServicioConexionFactibilidad.Queries
{
    using Application.SQLContext.SolServicioConexionFactibilidad.DTOs;
    using AutoMapper;
    using Core.Interfaces.SQLContext;
    using MediatR;

    public class SolServicioConexionFactibilidadSearchAllQueryHandler
    : IRequestHandler<
        SolServicioConexionFactibilidadSearchAllQuery,
        List<SolServicioConexionFactibilidadDTO>>
    {
        private readonly ISolServicioConexionFactibilidadService _solServicioConexionFactibilidadService;
        private readonly IMapper _mapper;

        public SolServicioConexionFactibilidadSearchAllQueryHandler(
            ISolServicioConexionFactibilidadService solServicioConexionFactibilidadService,
            IMapper mapper)
        {
            _solServicioConexionFactibilidadService = solServicioConexionFactibilidadService;
            _mapper = mapper;
        }

        public async Task<List<SolServicioConexionFactibilidadDTO>> Handle(SolServicioConexionFactibilidadSearchAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _solServicioConexionFactibilidadService.GetEntities();
            return _mapper.Map<List<SolServicioConexionFactibilidadDTO>>(entities);
        }
    }
}
