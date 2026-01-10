using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoConexionRepository : BaseRepository<TipoConexion>, ITipoConexionRepository
    {
        public TipoConexionRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoConexion> CreateEntity(TipoConexion entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoConexion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoConexion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoConexion> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoConexion> UpdateEntity(TipoConexion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
