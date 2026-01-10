namespace Application.SQLContext.SolConexionAutogen.Queries
{
    using Application.SQLContext.SolConexionAutogen.DTOs;
    using AutoMapper;
    using Core.Interfaces.SQLContext;
    using MediatR;

    public class SolConexionAutogenSearchByIdQueryHandler
    : IRequestHandler<SolConexionAutogenSearchByIdQuery, SolConexionAutogenDTO>
    {
        private readonly ISolConexionAutogenService _solConexionAutogenService;
        private readonly IMapper _mapper;

        public SolConexionAutogenSearchByIdQueryHandler(
            ISolConexionAutogenService solConexionAutogenService,
            IMapper mapper)
        {
            _solConexionAutogenService = solConexionAutogenService;
            _mapper = mapper;
        }

        public async Task<SolConexionAutogenDTO> Handle(SolConexionAutogenSearchByIdQuery request, CancellationToken cancellationToken)
        {
            var solConAutogen = new Core.Entities.SQLContext.SolConexionAutogen{Id = request.Id,};

            var entity = await _solConexionAutogenService.GetEntity(solConAutogen);
            return _mapper.Map<SolConexionAutogenDTO>(entity);
        }
    }
}
