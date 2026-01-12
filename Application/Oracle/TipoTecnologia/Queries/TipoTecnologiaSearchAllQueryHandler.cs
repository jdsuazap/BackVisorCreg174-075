namespace Application.Oracle.TipoTecnologia.Queries
{
    using Application.Oracle.TipoTecnologia.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class TipoTecnologiaSearchAllQueryHandler : IRequestHandler<TipoTecnologiaSearchAllQuery, List<TipoTecnologiaDTO>>
    {
        private readonly ITipoTecnologiaService _tipoTecnologiaService;
        private readonly IMapper _mapper;

        public TipoTecnologiaSearchAllQueryHandler(ITipoTecnologiaService tipoTecnologiaService, IMapper mapper)
        {
            _tipoTecnologiaService = tipoTecnologiaService;
            _mapper = mapper;
        }

        public async Task<List<TipoTecnologiaDTO>> Handle(TipoTecnologiaSearchAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _tipoTecnologiaService.GetEntities();
            return _mapper.Map<List<TipoTecnologiaDTO>>(entities);
        }
    }
}
