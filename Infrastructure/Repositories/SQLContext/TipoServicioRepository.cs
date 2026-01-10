using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoServicioRepository : BaseRepository<TipoServicio>, ITipoServicioRepository
    {
        public TipoServicioRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoServicio> CreateEntity(TipoServicio entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoServicio entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoServicio>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoServicio> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoServicio> UpdateEntity(TipoServicio entity)
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
