using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoAccionRepository : BaseRepository<TipoAccion>, ITipoAccionRepository
    {
        public TipoAccionRepository(DbSQLContext context) : base(context) { }

        public async Task<TipoAccion> CreateEntity(TipoAccion entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEntity(TipoAccion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoAccion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoAccion> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoAccion> UpdateEntity(TipoAccion entity)
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
