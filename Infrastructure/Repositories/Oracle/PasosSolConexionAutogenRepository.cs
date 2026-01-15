namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;    
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;
    public class PasosSolConexionAutogenRepository : BaseRepositoryDapperOracle<Creg174Pasos>, IPasosSolConexionAutogenRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public PasosSolConexionAutogenRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<Creg174Pasos> CreateEntity(Creg174Pasos entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(Creg174Pasos entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;

            await Update(entidad);

            return true;
        }

        public async Task<List<Creg174Pasos>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<Creg174Pasos> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<Creg174Pasos> GetLastEntityBySolConexion(int idSolConexion)
        {
            var pasoSolConexion = await _context.Creg174Pasos.Where(paso => paso.Cod174Autogen == idSolConexion)
                                                                         .OrderByDescending(paso => paso.Id)
                                                                         .FirstOrDefaultAsync();
            return pasoSolConexion;
        }

        public async Task<Creg174Pasos> UpdateEntity(Creg174Pasos entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Cod174Autogen = entity.Cod174Autogen;
            entidad.CodEstado = entity.CodEstado;            
            entidad.Estado = entity.Estado;            

            await Update(entidad);

            return entidad;
        }
    }
}
