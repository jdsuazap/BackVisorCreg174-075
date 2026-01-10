using Core.Entities;
using Core.Entities.SQLContext;
using Core.ModelResponse;

namespace Core.Interfaces.SQLContext
{
    public interface IEmpresasRepository
    {
        Task<List<Empresa>> GetEmpresas();
        Task<List<Empresa>> GetListEmpresas();
        Task<List<ResponseAction>> PostCrear(Empresa empresa);
        Task<List<ResponseAction>> PutEmpresa(Empresa empresa);
        Task<List<ResponseAction>> DeleteEmpresa(Empresa empresa);
    }
}
