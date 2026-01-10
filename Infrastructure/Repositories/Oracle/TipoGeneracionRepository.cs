using Core.Entities.Oracle;
using Core.Interfaces.Oracle;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories.Oracle
{
    public class TipoGeneracionRepository : BaseRepositoryDapperOracle<CregTipoGeneracion>, ITipoGeneracionRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public TipoGeneracionRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<CregTipoGeneracion> CreateEntity(CregTipoGeneracion entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregTipoGeneracion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            await Update(entidad);

            return true;
        }

        public async Task<List<CregTipoGeneracion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<CregTipoGeneracion> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<CregTipoGeneracion> UpdateEntity(CregTipoGeneracion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Abreviatura = entity.Abreviatura;
            entidad.Estado = entity.Estado;

            await Update(entidad);

            return entidad;
        }
    }
}
