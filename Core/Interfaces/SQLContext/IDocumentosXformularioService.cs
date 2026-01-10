namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;
    public interface IDocumentosXformularioService
    {
        Task<List<DocumentosXformulario>> GetEntities();
    }
}
