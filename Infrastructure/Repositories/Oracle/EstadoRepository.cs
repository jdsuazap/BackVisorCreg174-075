namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using System.Linq.Expressions;

    public class EstadoRepository : BaseRepositoryDapperOracle<CregEstado>, IEstadoRepository
    {
        private readonly Expression<Func<CregEstado, object>>[] IncludeProperties = new Expression<Func<CregEstado, object>>[]
        {
            // Agrega aquí las propiedades de navegación que deseas incluir
            //entity => entity.CodTipoEstadoNavigation,
        };

        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public EstadoRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<CregEstado> CreateEntity(CregEstado entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(CregEstado entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;

            await Update(entidad);

            return true;
        }

        public async Task<List<CregEstado>> GetEntities()
        {
            return await GetAll(includeObjectProperties: IncludeProperties);
        }

        public async Task<List<CregEstado>> GetEntitiesByIdTipoEstado(int idTipoEstado)
        {
            return await GetAll(filter: x => x.CodTipoEstado == idTipoEstado, includeObjectProperties: IncludeProperties);
        }

        public async Task<CregEstado> GetEntity(int idEntity)
        {
            return (await GetAll(filter: x => x.Id == idEntity, includeObjectProperties: IncludeProperties)).FirstOrDefault();
        }

        public async Task<CregEstado> UpdateEntity(CregEstado entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodTipoEstado = entity.CodTipoEstado;
            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;            

            await Update(entidad);

            return entidad;
        }
    }
}
