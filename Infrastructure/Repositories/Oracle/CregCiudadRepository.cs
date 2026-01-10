namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;


    public class CregCiudadRepository : BaseRepositoryDapperOracle<CregCiudad>, ICregCiudadRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public CregCiudadRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<CregCiudad> CreateEntity(CregCiudad entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregCiudad entity)
        {
            var entidad = await GetById(Convert.ToInt32(entity.Id));

            entidad.Estado = false;
            await Update(entidad);

            return true;
        }

        public async Task<List<CregCiudad>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<List<CregCiudad>> GetEntitiesByDepartamento(string idEntityDpto)
        {
            return await _context.CregCiudads.Where(x => x.CodDepartamento == idEntityDpto).ToListAsync();
        }

        public async Task<CregCiudad> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<CregCiudad> UpdateEntity(CregCiudad entity)
        {
            var entidad = await GetById(Convert.ToInt32(entity.Id));

            //entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;

            await Update(entidad);

            return entidad;
        }
    }
}
