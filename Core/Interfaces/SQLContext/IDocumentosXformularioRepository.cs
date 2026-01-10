namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;

    public interface IDocumentosXformularioRepository
    {
        Task<List<DocumentosXformulario>> GetEntities();       
    }
}
