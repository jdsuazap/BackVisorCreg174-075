namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using System.Data;
    public class TipoConstruccionRepository : BaseRepositoryDapperOracle<CregTipoConstruccion>, ITipoConstruccionRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public TipoConstruccionRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<CregTipoConstruccion> CreateEntity(CregTipoConstruccion entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregTipoConstruccion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;

            await Update(entidad);

            return true;
        }

        public async Task<List<CregTipoConstruccion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<CregTipoConstruccion> GetEntity(int idTipoConstruccion)
        {
            return await GetById(idTipoConstruccion);
        }

        public async Task<CregTipoConstruccion> UpdateEntity(CregTipoConstruccion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;

            await Update(entidad);

            return entidad;
        }
    }
}
