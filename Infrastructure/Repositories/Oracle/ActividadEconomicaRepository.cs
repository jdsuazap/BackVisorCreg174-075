namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;

    public class ActividadEconomicaRepository : BaseRepositoryDapperOracle<CregActividadEconomica>, IActividadEconomicaRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public ActividadEconomicaRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";
        public async Task<CregActividadEconomica> CreateEntity(CregActividadEconomica entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregActividadEconomica entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;

            await Update(entidad);

            return true;
        }

        public async Task<List<CregActividadEconomica>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<CregActividadEconomica> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<CregActividadEconomica> UpdateEntity(CregActividadEconomica entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;

            await Update(entidad);

            return entidad;
        }
    }
}
