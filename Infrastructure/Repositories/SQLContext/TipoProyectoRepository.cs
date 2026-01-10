using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoProyectoRepository : BaseRepository<TipoProyecto>, ITipoProyectoRepository
    {
        public TipoProyectoRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoProyecto> CreateEntity(TipoProyecto entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoProyecto entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoProyecto>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoProyecto> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoProyecto> UpdateEntity(TipoProyecto entity)
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
