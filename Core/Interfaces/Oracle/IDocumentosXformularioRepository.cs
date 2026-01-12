namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;

    public interface IDocumentosXformularioRepository
    {
        Task<List<CregDocumentosFormulario>> GetEntities();

        Task<List<CregDocumentosFormulario>> GetEntitiesByCodFormulario(int codFormularioPrincipal);

    }
}
