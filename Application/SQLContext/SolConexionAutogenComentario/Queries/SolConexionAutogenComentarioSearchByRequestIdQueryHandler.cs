namespace Application.SQLContext.SolConexionAutogenComentario.Queries
{
    using Application.SQLContext.SolConexionAutogenComentario.DTOs;
    using AutoMapper;
    using Core.Interfaces.SQLContext;
    using MediatR;


    public class SolConexionAutogenComentarioSearchByRequestIdQueryHandler : IRequestHandler<SolConexionAutogenComentarioSearchByRequestIdQuery, List<SolConexionAutogenComentarioDTO>>
    {
        private readonly ISolConexionAutogenComentarioService _solConexionAutogenComentarioService;
        private readonly IMapper _mapper;

        public SolConexionAutogenComentarioSearchByRequestIdQueryHandler(ISolConexionAutogenComentarioService solConexionAutogenComentarioService, IMapper mapper)
        {
            _solConexionAutogenComentarioService = solConexionAutogenComentarioService;
            _mapper = mapper;
        }

        public async Task<List<SolConexionAutogenComentarioDTO>> Handle(SolConexionAutogenComentarioSearchByRequestIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _solConexionAutogenComentarioService.GetEntitiesByRequest(request.Id);
            return _mapper.Map<List<SolConexionAutogenComentarioDTO>>(entities);
        }
    }
}
