using Application.SQLContext.SolConexionAutogen.DTOs;
using AutoMapper;
using Core.Interfaces.SQLContext;
using MediatR;

namespace Application.SQLContext.SolConexionAutogen.Queries
{
    public class SolConexionAutogenParametrosInicialesQueryHandler : IRequestHandler<SolConexionAutogenParametrosInicialesQuery, SolConexionAutogenParamsIniDTO>
    {
        private readonly ISolConexionAutogenService _solConexionAutogenService;
        private readonly IMapper _mapper;

        public SolConexionAutogenParametrosInicialesQueryHandler(ISolConexionAutogenService solConexionAutogenService, IMapper mapper)
        {
            _solConexionAutogenService = solConexionAutogenService;
            _mapper = mapper;
        }

        public async Task<SolConexionAutogenParamsIniDTO> Handle(SolConexionAutogenParametrosInicialesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _solConexionAutogenService.GetParametrosIniciales();
            return _mapper.Map<SolConexionAutogenParamsIniDTO>(entities);
        }
    }
}
