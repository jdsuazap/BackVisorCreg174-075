namespace Application.Oracle.Departamento.Queries
{
    using Application.Oracle.Departamento.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class DepartamentoSearchAllQueryHandler
    : IRequestHandler<DepartamentoSearchAllQuery, List<DepartamentoDTO>>
    {
        private readonly IDepartamentoService _departamentoService;
        private readonly IMapper _mapper;

        public DepartamentoSearchAllQueryHandler(
            IDepartamentoService departamentoService,
            IMapper mapper)
        {
            _departamentoService = departamentoService;
            _mapper = mapper;
        }

        public async Task<List<DepartamentoDTO>> Handle(DepartamentoSearchAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _departamentoService.GetEntities();
            return _mapper.Map<List<DepartamentoDTO>>(entities);
        }
    }
}
