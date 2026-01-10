namespace Application.Oracle.Ciudad.Queries
{
    using Application.Oracle.Ciudad.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CiudadSearchByDptoQueryHandler
     : IRequestHandler<CiudadSearchByDptoQuery, List<CiudadDTO>>
    {
        private readonly ICregCiudadService _ciudadService;
        private readonly IMapper _mapper;

        public CiudadSearchByDptoQueryHandler(
            ICregCiudadService ciudadService,
            IMapper mapper)
        {
            _ciudadService = ciudadService;
            _mapper = mapper;
        }

        public async Task<List<CiudadDTO>> Handle(CiudadSearchByDptoQuery request, CancellationToken cancellationToken)
        {
            var entity = await _ciudadService.GetEntitiesByDepartamento(request.CodDepartamento);
            return _mapper.Map<List<CiudadDTO>>(entity);
        }
    }
}
