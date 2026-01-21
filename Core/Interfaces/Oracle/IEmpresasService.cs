namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface IEmpresasService
    {
        public List<CregEmpresa> EmpresasActivas { get; set; }

        Task<CregEmpresa> CreateEntity(CregEmpresa entity);
        Task<List<CregEmpresa>> GetEmpresas();
        Task<CregEmpresa> GetEntity(int idEntity);
        Task<CregEmpresa> PutEmpresa(CregEmpresa empresa);
        Task<bool> DeleteEmpresa(CregEmpresa entity);
    }
}
