using Application.SQLContext.SolServicioConexionDisenio.DTOs;
using AutoMapper;
using Core.Interfaces.SQLContext;
using MediatR;
using System.Linq.Expressions;

namespace Application.SQLContext.SolServicioConexionDisenio.Queries
{
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
            Expression<Func<Core.Entities.SQLContext.SolServicioConexionDisenio, object>>[] includes = {
                };
            var entity = (await _SolServicioConexionDisenioService.GetAllAsync(filter: x=> x.CodServicioConexion == request.Id && x.Estado.HasValue && x.Estado.Value , 
                                                                              includeObjectProperties: includes)).FirstOrDefault();

            return _mapper.Map<SolServicioConexionDisenioDTO>(entity);
        }
    }
}
