namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;

    public class EstratoSocioeconomicoRepository : BaseRepositoryDapperOracle<CregEstratoSocioeconomico>, IEstratoSocioeconomicoRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public EstratoSocioeconomicoRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<CregEstratoSocioeconomico> CreateEntity(CregEstratoSocioeconomico entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregEstratoSocioeconomico entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;

            await Update(entidad);

            return true;
        }

        public async Task<List<CregEstratoSocioeconomico>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<CregEstratoSocioeconomico> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<CregEstratoSocioeconomico> UpdateEntity(CregEstratoSocioeconomico entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;

            await Update(entidad);

            return entidad;
        }
    }
}
