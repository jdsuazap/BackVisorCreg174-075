using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoSolicitudServicioRepository : BaseRepository<TipoSolicitudServicio>, ITipoSolicitudServicioRepository
    {
        public TipoSolicitudServicioRepository(DbSQLContext context) : base(context) { }

        public async Task<TipoSolicitudServicio> CreateEntity(TipoSolicitudServicio entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoSolicitudServicio entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoSolicitudServicio>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoSolicitudServicio> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoSolicitudServicio> UpdateEntity(TipoSolicitudServicio entity)
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
