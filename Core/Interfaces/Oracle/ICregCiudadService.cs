namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;

    public interface ICregCiudadService
    {
        Task<List<CregCiudad>> GetEntitiesByDepartamento(string idEntityDpto);
    }
}
