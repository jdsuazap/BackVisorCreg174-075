using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoGeneracionRepository : BaseRepository<TipoGeneracion>, ITipoGeneracionRepository
    {
        public TipoGeneracionRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoGeneracion> CreateEntity(TipoGeneracion entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoGeneracion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoGeneracion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoGeneracion> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoGeneracion> UpdateEntity(TipoGeneracion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Abreviatura = entity.Abreviatura;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
