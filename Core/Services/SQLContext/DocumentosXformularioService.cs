namespace Core.Services.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;

    public class DocumentosXformularioService : IDocumentosXformularioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentosXformularioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DocumentosXformulario>> GetEntities()
        {
            return await _unitOfWork.DocumentosXformularioRepository.GetEntities();
        }        
    }
}
