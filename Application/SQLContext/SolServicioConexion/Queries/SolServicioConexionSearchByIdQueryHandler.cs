//namespace Application.SQLContext.SolServicioConexion.Queries
//{
//    using Application.SQLContext.SolServicioConexion.DTOs;
//    using AutoMapper;
//    using Core.Interfaces;
//    using Core.Interfaces.SQLContext;
//    using MediatR;

//    public class SolServicioConexionSearchByIdQueryHandler : SolServicioConexionListQueryBase, IRequestHandler<SolServicioConexionSearchByIdQuery, SolServicioConexionDTO>
//    {
//        private readonly ISolServicioConexionService _solServicioConexionService;

//        public SolServicioConexionSearchByIdQueryHandler(ISolServicioConexionService solServicioConexionService,
//            IMapper mapper,
//            IUnitOfWork unitOfWork)
//            : base(mapper,
//                  unitOfWork)
//        {
//            _solServicioConexionService = solServicioConexionService;
//        }

//        public async Task<SolServicioConexionDTO> Handle(SolServicioConexionSearchByIdQuery request, CancellationToken cancellationToken)
//        {
//            var solServicio = new Core.Entities.SQLContext.SolServicioConexion
//            {
//                Id = request.Id,
//            };

//            var entity = await _solServicioConexionService.GetEntity(solServicio.Id);

//            var entities = await GetDtoListAsync(new List<Core.Entities.SQLContext.SolServicioConexion>() { entity }, true);
//            return entities.First();
//        }
//    }
//}
