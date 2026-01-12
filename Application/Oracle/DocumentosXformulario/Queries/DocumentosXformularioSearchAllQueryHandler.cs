namespace Application.Oracle.DocumentosXformulario.Queries
{
    using Application.Oracle.DocumentosXformulario.DTOs;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class DocumentosXformularioSearchAllQueryHandler
    : IRequestHandler<
        DocumentosXformularioSearchAllQuery,
        List<DocumentosXformularioDTO>
      >
    {
        private readonly IDocumentosXformularioService _documentosXformularioService;
        private readonly IMapper _mapper;

        public DocumentosXformularioSearchAllQueryHandler(
            IDocumentosXformularioService documentosXformularioService,
            IMapper mapper)
        {
            _documentosXformularioService = documentosXformularioService;
            _mapper = mapper;
        }

        public async Task<List<DocumentosXformularioDTO>> Handle(DocumentosXformularioSearchAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _documentosXformularioService.GetEntities();
            return _mapper.Map<List<DocumentosXformularioDTO>>(entities);
        }
    }
}
