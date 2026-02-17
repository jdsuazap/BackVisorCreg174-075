namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using System.Threading.Tasks;

    public class SolServicioConexionFactibilidadRepository : BaseRepositoryDapperOracle<Creg075Factibilidad>, ISolServicioConexionFactibilidadRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public SolServicioConexionFactibilidadRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";
       
        public async Task<Creg075Factibilidad> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<List<Creg075Factibilidad>> GetEntities()
        {
            return await GetAll();
        }
    }
}
