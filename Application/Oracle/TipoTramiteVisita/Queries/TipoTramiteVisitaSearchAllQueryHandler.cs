namespace Application.Oracle.TipoTramiteVisita.Queries
{
    using Application.Oracle.TipoTramiteVisita.DTOs;
    using Application.Oracle.TipoTramiteVisita.Queries;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class TipoTramiteVisitaSearchAllQueryHandler : IRequestHandler<TipoTramiteVisitaSearchAllQuery, List<TipoTramiteVisitaDTO>>
    {
        private readonly ITipoTramiteVisitaService _tipoTramiteVisitaService;
        private readonly IMapper _mapper;

        public TipoTramiteVisitaSearchAllQueryHandler(ITipoTramiteVisitaService tipoTramiteVisitaService, IMapper mapper)
        {
            _tipoTramiteVisitaService = tipoTramiteVisitaService;
            _mapper = mapper;
        }

        public async Task<List<TipoTramiteVisitaDTO>> Handle(TipoTramiteVisitaSearchAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _tipoTramiteVisitaService.GetEntities();
            return _mapper.Map<List<TipoTramiteVisitaDTO>>(entities);
        }
    }
}
