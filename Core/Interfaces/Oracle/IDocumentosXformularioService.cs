namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface IDocumentosXformularioService
    {
        Task<List<CregDocumentosFormulario>> GetEntities();
    }
}
