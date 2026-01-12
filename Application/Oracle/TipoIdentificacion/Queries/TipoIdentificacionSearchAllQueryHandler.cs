namespace Application.Oracle.TipoIdentificacion.Queries
{
    using Application.Oracle.TipoIdentificacion.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;
    public class TipoIdentificacionSearchAllQueryHandler : IRequestHandler<TipoIdentificacionSearchAllQuery, List<TipoIdentificacionDTO>>
    {
        private readonly ITipoIdentificacionService _tipoIdentificacionService;
        private readonly IMapper _mapper;

        public TipoIdentificacionSearchAllQueryHandler(ITipoIdentificacionService tipoIdentificacionService, IMapper mapper)
        {
            _tipoIdentificacionService = tipoIdentificacionService;
            _mapper = mapper;
        }

        public async Task<List<TipoIdentificacionDTO>> Handle(TipoIdentificacionSearchAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _tipoIdentificacionService.GetEntities();
            return _mapper.Map<List<TipoIdentificacionDTO>>(entities);
        }
    }
}
