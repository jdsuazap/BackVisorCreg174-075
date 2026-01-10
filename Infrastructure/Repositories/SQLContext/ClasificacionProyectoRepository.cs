using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class ClasificacionProyectoRepository : BaseRepository<ClasificacionProyecto>, IClasificacionProyectoRepository
    {
        public ClasificacionProyectoRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<ClasificacionProyecto> CreateEntity(ClasificacionProyecto entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(ClasificacionProyecto entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<ClasificacionProyecto>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<ClasificacionProyecto> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<ClasificacionProyecto> UpdateEntity(ClasificacionProyecto entity)
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
