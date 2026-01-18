namespace Application.Oracle.SolServicioConexion.Queries
{
    using Application.Oracle.SolServicioConexion.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class SolServicioConexionParametrosInicialesQueryHandler : IRequestHandler<SolServicioConexionParametrosInicialesQuery, SolServicioConexionParamsIniDTO>
    {
        private readonly ISolServicioConexionService _solServicioConexionService;
        private readonly IMapper _mapper;

        public SolServicioConexionParametrosInicialesQueryHandler(ISolServicioConexionService solServicioConexionService, IMapper mapper)
        {
            _solServicioConexionService = solServicioConexionService;
            _mapper = mapper;
        }

        public async Task<SolServicioConexionParamsIniDTO> Handle(SolServicioConexionParametrosInicialesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _solServicioConexionService.GetParametrosIniciales();
            return _mapper.Map<SolServicioConexionParamsIniDTO>(entities);
        }
    }
}
