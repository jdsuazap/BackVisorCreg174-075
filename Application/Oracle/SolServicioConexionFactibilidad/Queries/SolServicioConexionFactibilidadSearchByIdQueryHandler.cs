namespace Application.Oracle.SolServicioConexionFactibilidad.Queries
{
    using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class SolServicioConexionFactibilidadSearchByIdQueryHandler: IRequestHandler<SolServicioConexionFactibilidadSearchByIdQuery, SolServicioConexionFactibilidadDTO>
    {
        private readonly ISolServicioConexionFactibilidadService _solServicioConexionFactibilidadService;
        private readonly IMapper _mapper;

        public SolServicioConexionFactibilidadSearchByIdQueryHandler(ISolServicioConexionFactibilidadService solServicioConexionFactibilidadService, IMapper mapper)
        {
            _solServicioConexionFactibilidadService = solServicioConexionFactibilidadService;
            _mapper = mapper;
        }
      
        public async Task<SolServicioConexionFactibilidadDTO> Handle(SolServicioConexionFactibilidadSearchByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _solServicioConexionFactibilidadService.GetEntityByIdSolicitud(request.Numero_Radicado, request.Empresa);
            return _mapper.Map<SolServicioConexionFactibilidadDTO>(entity);
        }        
    }
}
