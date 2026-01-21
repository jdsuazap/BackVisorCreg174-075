namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;

    public interface IEmpresasRepository
    {
        Task<CregEmpresa> CreateEntity(CregEmpresa entity);
        Task<List<CregEmpresa>> GetEmpresas();
        Task<CregEmpresa> GetEntity(int idEntity);
        Task<CregEmpresa> PutEmpresa(CregEmpresa empresa);
        Task<bool> DeleteEmpresa(CregEmpresa entity);
    }
}
