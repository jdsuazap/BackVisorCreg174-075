namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using System.Linq.Expressions;

    public class DocumentosXformularioService : IDocumentosXformularioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentosXformularioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CregDocumentosFormulario>> GetAll(
           Expression<Func<CregDocumentosFormulario, bool>> filter = null,
           Func<IQueryable<CregDocumentosFormulario>, IOrderedQueryable<CregDocumentosFormulario>> orderBy = null,
           Func<IQueryable<CregDocumentosFormulario>, IOrderedQueryable<CregDocumentosFormulario>> orderByDescending = null,
           bool isTracking = false,
           params Expression<Func<CregDocumentosFormulario, object>>[] includeObjectProperties)
        {
            return await _unitOfWork.DocumentosXformularioRepository.GetAll(filter, orderBy, orderByDescending, isTracking, includeObjectProperties);
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
