namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;

    public class TipoTensionRepository : BaseRepositoryDapperOracle<CregTipoTension>, ITipoTensionRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public TipoTensionRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<CregTipoTension> CreateEntity(CregTipoTension entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregTipoTension entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;

            await Update(entidad);

            return true;
        }

        public async Task<List<CregTipoTension>> GetEntities()
        {
            return await GetAll(x => x.Estado == true);
        }

        public async Task<CregTipoTension> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<CregTipoTension> UpdateEntity(CregTipoTension entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Nivel = entity.Nivel;
            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;

            await Update(entidad);

            return entidad;
        }
    }
}
