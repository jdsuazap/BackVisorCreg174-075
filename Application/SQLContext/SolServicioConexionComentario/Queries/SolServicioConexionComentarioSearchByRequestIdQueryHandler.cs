using Application.SQLContext.SolServicioConexionComentario.DTOs;
using AutoMapper;
using Core.Interfaces.SQLContext;
using MediatR;

namespace Application.SQLContext.SolServicioConexionComentario.Queries
{
    public class SolServicioConexionComentarioSearchByRequestIdQueryHandler : IRequestHandler<SolServicioConexionComentarioSearchByRequestIdQuery, List<SolServicioConexionComentarioDTO>>
    {
        private readonly ISolServicioConexionComentarioService _solServicioConexionComentarioService;
        private readonly IMapper _mapper;

        public SolServicioConexionComentarioSearchByRequestIdQueryHandler(ISolServicioConexionComentarioService solServicioConexionComentarioService, IMapper mapper)
        {
            _solServicioConexionComentarioService = solServicioConexionComentarioService;
            _mapper = mapper;
        }

        public async Task<List<SolServicioConexionComentarioDTO>> Handle(SolServicioConexionComentarioSearchByRequestIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _solServicioConexionComentarioService.GetEntitiesByRequest(request.Id);
            return _mapper.Map<List<SolServicioConexionComentarioDTO>>(entities);
        }
    }
}
