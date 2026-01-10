using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoCompletitudRepository : BaseRepository<TipoCompletitud>, ITipoCompletitudRepository
    {
        public TipoCompletitudRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoCompletitud> CreateEntity(TipoCompletitud entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoCompletitud entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoCompletitud>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoCompletitud> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoCompletitud> UpdateEntity(TipoCompletitud entity)
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
