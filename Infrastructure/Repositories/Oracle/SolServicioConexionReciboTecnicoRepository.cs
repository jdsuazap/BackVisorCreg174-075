namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;

    public class SolServicioConexionReciboTecnicoRepository : BaseRepositoryDapperOracle<Creg075ReciboTecnico>, ISolServicioConexionReciboTecnicoRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public SolServicioConexionReciboTecnicoRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<List<Creg075ReciboTecnico>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<Creg075ReciboTecnico> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }
    }
}
