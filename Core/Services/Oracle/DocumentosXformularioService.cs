namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class DocumentosXformularioService : IDocumentosXformularioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentosXformularioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CregDocumentosFormulario>> GetEntities()
        {
            return await _unitOfWork.DocumentosXformularioRepository.GetEntities();
        }

        public async Task<List<CregDocumentosFormulario>> GetEntitiesByCodFormulario(int codFormularioPrincipal)
        {
            return await _unitOfWork.DocumentosXformularioRepository.GetEntitiesByCodFormulario(codFormularioPrincipal);
        }
    }
}
