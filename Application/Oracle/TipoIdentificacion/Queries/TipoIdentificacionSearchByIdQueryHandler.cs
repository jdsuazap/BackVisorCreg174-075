namespace Application.Oracle.TipoIdentificacion.Queries
{
    using Application.Oracle.TipoIdentificacion.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;
    public class TipoIdentificacionSearchByIdQueryHandler : IRequestHandler<TipoIdentificacionSearchByIdQuery, TipoIdentificacionDTO>
    {
        private readonly ITipoIdentificacionService _tipoIdentificacionService;
        private readonly IMapper _mapper;

        public TipoIdentificacionSearchByIdQueryHandler(ITipoIdentificacionService tipoIdentificacionService, IMapper mapper)
        {
            _tipoIdentificacionService = tipoIdentificacionService;
            _mapper = mapper;
        }

        public async Task<TipoIdentificacionDTO> Handle(TipoIdentificacionSearchByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _tipoIdentificacionService.GetEntity(request.Id);
            return _mapper.Map<TipoIdentificacionDTO>(entity);
        }
    }
}
