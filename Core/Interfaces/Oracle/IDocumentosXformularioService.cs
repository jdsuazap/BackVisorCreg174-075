namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    using System.Linq.Expressions;

    public interface IDocumentosXformularioService
    {
        Task<List<CregDocumentosFormulario>> GetEntities();

        Task<List<CregDocumentosFormulario>> GetAll(
           Expression<Func<CregDocumentosFormulario, bool>> filter = null,
           Func<IQueryable<CregDocumentosFormulario>, IOrderedQueryable<CregDocumentosFormulario>> orderBy = null,
           Func<IQueryable<CregDocumentosFormulario>, IOrderedQueryable<CregDocumentosFormulario>> orderByDescending = null,
           bool isTracking = false,
           params Expression<Func<CregDocumentosFormulario, object>>[] includeObjectProperties);
    }
}
