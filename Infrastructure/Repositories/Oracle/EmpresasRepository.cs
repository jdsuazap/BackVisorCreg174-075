namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Exceptions;
    using Core.Interfaces.Oracle;
    using Core.ModelResponse;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using Infrastructure.Utils;
    using Microsoft.EntityFrameworkCore;

    public class EmpresasRepository : BaseRepositoryDapperOracle<CregEmpresa>, IEmpresasRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public EmpresasRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";


        public async Task<CregEmpresa> CreateEntity(CregEmpresa entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<List<CregEmpresa>> GetEmpresas()
        {
            return await GetAll();
        }

        public async Task<CregEmpresa> GetEntity(int idEntity)
        {
            return (await GetAll(filter: x => x.Id == idEntity)).FirstOrDefault();
        }

        public async Task<CregEmpresa> PutEmpresa(CregEmpresa empresa)
        {
            var entidad = await GetById(empresa.Id);

            entidad.Nit = empresa.Nit;
            entidad.Nombre = empresa.Nombre;
            entidad.NombreGnr = empresa.NombreGnr;
            entidad.Direccion = empresa.Direccion;
            entidad.Ciudad = empresa.Ciudad;
            entidad.Telefono = empresa.Telefono;
            entidad.Abreviatura = empresa.Abreviatura;
            entidad.TrbCodTrabRepLegal = empresa.TrbCodTrabRepLegal;
            entidad.Tope = empresa.Tope;
            entidad.IsBimestralApot = empresa.IsBimestralApot;
            entidad.CuentaApot = empresa.CuentaApot;
            entidad.TipoDocAltApot = empresa.TipoDocAltApot;
            entidad.CodArchivo = empresa.CodArchivo;
            entidad.Estado = empresa.Estado;

            await Update(entidad);

            return entidad;
        }

        public async Task<bool> DeleteEmpresa(CregEmpresa entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;

            await Update(entidad);

            return true;
        }
    }


}
