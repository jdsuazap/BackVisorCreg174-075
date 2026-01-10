namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;

    public interface IDepartamentoService
    {
        Task<List<CregDepartamento>> GetEntities();
    }
}
