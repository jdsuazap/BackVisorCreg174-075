namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;

    public class DepartamentoRepository : BaseRepositoryDapperOracle<CregDepartamento>, IDepartamentoRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public DepartamentoRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<CregDepartamento> CreateEntity(CregDepartamento entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregDepartamento entity)
        {
            var entidad = await GetById(Convert.ToInt32(entity.Id));

            entidad.Estado = false;
            await Update(entidad);

            return true;
        }

        public async Task<List<CregDepartamento>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<CregDepartamento> GetEntity(string idEntity)
        {
            return await GetById(Convert.ToInt32(idEntity));
        }

        public async Task<CregDepartamento> UpdateEntity(CregDepartamento entity)
        {
            var entidad = await GetById(Convert.ToInt32(entity.Id));

            //entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;
            await Update(entidad);

            return entidad;
        }
    }
}
