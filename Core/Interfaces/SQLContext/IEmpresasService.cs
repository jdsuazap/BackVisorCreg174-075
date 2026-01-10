using Core.Entities.SQLContext;
using Core.ModelResponse;

namespace Core.Interfaces.SQLContext
{
    public interface IEmpresasService
    {
        public List<Empresa> EmpresasActivas { get; set; }

        Task<List<Empresa>> GetEmpresas();
        Task<List<Empresa>> GetListEmpresas();
        Task<List<ResponseAction>> PostCrear(Empresa empresa);
        Task<List<ResponseAction>> PutEmpresa(Empresa empresa);
        Task<List<ResponseAction>> DeleteEmpresa(Empresa empresa);
    }
}
