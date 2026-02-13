namespace Application.Oracle.SolServicioConexionDisenio.Queries
{
    using Application.Oracle.SolServicioConexionDisenio.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;
    using System.Linq.Expressions;

    public class SolServicioConexionDisenioSearchByIdQueryHandler : IRequestHandler<SolServicioConexionDisenioSearchByIdQuery, SolServicioConexionDisenioDTO>
    {
        private readonly ISolServicioConexionDisenioService _SolServicioConexionDisenioService;
        private readonly IMapper _mapper;

        public SolServicioConexionDisenioSearchByIdQueryHandler(ISolServicioConexionDisenioService accionService, IMapper mapper)
        {
            _SolServicioConexionDisenioService = accionService;
            _mapper = mapper;
        }
        public async Task<SolServicioConexionDisenioDTO> Handle(SolServicioConexionDisenioSearchByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Core.Entities.Oracle.Creg075Disenio, object>>[] includes = {
                    x => x.Creg075DisenioActor,
                    x => x.Creg075DisenioAnexo,
                    x => x.Creg075DisenioDocu
                };
            var entity = (await _SolServicioConexionDisenioService.GetAll(filter: x=> x.Cod075Conexion == request.Id && x.Estado.HasValue && x.Estado.Value , 
                                                                              includeObjectProperties: includes)).FirstOrDefault();

            return _mapper.Map<SolServicioConexionDisenioDTO>(entity);
        }
    }
}
